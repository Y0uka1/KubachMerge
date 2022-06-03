using System;
using System.Collections.Generic;
using Databases;
using Entitas;
using GoogleMobileAds.Api;
using Zenject;

namespace ECS.Systems
{
    public class AdBannerSystem : /*ReactiveSystem<CommandEntity>,*/ IInitializable
    {
        private readonly IAdSettingsDatabase _adSettingsDatabase;
        private BannerView _bannerView;

        public AdBannerSystem(CommandContext context, IAdSettingsDatabase adSettingsDatabase) /*: base(context)*/
        {
            _adSettingsDatabase = adSettingsDatabase;
        }

        // protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
        // {
        //     return context.CreateCollector(CommandMatcher.AdBanner.Added());
        // }
        //
        // protected override bool Filter(CommandEntity entity)
        // {
        //     return !entity.isDestroyed && entity.isAdBanner;
        // }
        //
        // protected override void Execute(List<CommandEntity> entities)
        // {
        //     foreach (var entity in entities)
        //     {
        //         entity.isDestroyed = true;
        //         _bannerView.LoadAd(new AdRequest.Builder().Build());
        //     }
        // }

        public void Initialize()
        {
            _bannerView = new BannerView(_adSettingsDatabase.BannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
            _bannerView.OnAdFailedToLoad += (sender, args) =>
                throw new Exception($"[AdBannerSystem] Failed to load ad. Error:{args.LoadAdError}");
            _bannerView.LoadAd(new AdRequest.Builder().Build());
        }
    }
}