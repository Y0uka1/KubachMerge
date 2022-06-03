using System;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using Signals;
using UnityEngine;
using Zenject;

namespace Databases
{
    public class LocalizationProvider : ILocalizationProvider, IInitializable
    {
        private const string LOCALIZATION_PATH = "Localization/";
        private const string ENG_LOCALIZATION_POSTFIX = "ENG";
        private const string RU_LOCALIZATION_POSTFIX = "RU";
        private LocalizationPairVo[] _localizationPairs;
        [Inject] private readonly SignalBus _signalBus;

        public void SwitchLocalization(ELocalizationLanguage language)
        {
            switch (language)
            {
                case ELocalizationLanguage.RU:
                    LoadLocalization(RU_LOCALIZATION_POSTFIX);
                    break;
                case ELocalizationLanguage.ENG:
                    LoadLocalization(ENG_LOCALIZATION_POSTFIX);
                    break;
                default:
                    throw new Exception($"[LocalizationProvider] Localization for type {language} not found");
            }
        }
        public string Get(string key)
        {
            foreach (var pair in _localizationPairs)
            {
                if(pair.Key!=key)
                    continue;
                return pair.Value;
            }
#if UNITY_EDITOR
            throw new Exception($"[LocalizationProvider] Value for key {key} not found");
#endif
            return key;
        }

        public void Initialize()
        {
            LoadLocalization(ENG_LOCALIZATION_POSTFIX);
        }

        private void LoadLocalization(string postifx)
        {
            var localization = Resources.Load<TextAsset>($"{LOCALIZATION_PATH}{postifx}");
            var pairs = JsonUtility.FromJson<LocalizationJson>(localization.text);
            _localizationPairs = pairs.pairs.ToArray();
            _signalBus.Fire<SignalLocalizationChanged>();
        }
    }

    [Serializable]
    public class LocalizationJson
    {
        public List<LocalizationPairVo> pairs;
    }

    [Serializable]
    public class LocalizationPairVo
    {
        [SerializeField] public string Key;
        [SerializeField] public string Value;
    }
}