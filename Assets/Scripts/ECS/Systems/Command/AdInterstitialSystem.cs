using System;
using System.Collections.Generic;
using Databases;
using Entitas;
using General;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public class AdInterstitialSystem : ReactiveSystem<CommandEntity>, IInitializable
    {
        private readonly IAdSettingsDatabase _adSettingsDatabase;
        private InterstitialAd _interstitialAd;

        public AdInterstitialSystem(CommandContext context, IAdSettingsDatabase adSettingsDatabase) : base(context)
        {
            _adSettingsDatabase = adSettingsDatabase;
        }

        protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
        {
            return context.CreateCollector(CommandMatcher.AdInterstitial.Added());
        }

        protected override bool Filter(CommandEntity entity)
        {
            return !entity.isDestroyed && entity.isAdInterstitial;
        }

        protected override void Execute(List<CommandEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isDestroyed = true;
                _interstitialAd.LoadAd(new AdRequest.Builder().Build());
            }
        }

        public void Initialize()
        {
            _interstitialAd = new InterstitialAd(_adSettingsDatabase.InterstitialAdUnitId);
            _interstitialAd.OnAdLoaded += (sender, args) => _interstitialAd.Show();
            _interstitialAd.OnAdFailedToLoad += (sender, args) =>
                throw new Exception($"[AdInterstitialSystem] Failed to load ad. Error:{args.LoadAdError}");
        }
    }
}