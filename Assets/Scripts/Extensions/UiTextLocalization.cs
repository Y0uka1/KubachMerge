using System;
using Databases;
using Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Extensions
{
    public class UiTextLocalization:MonoBehaviour
    {
        [SerializeField] private string key;

        private ILocalizationProvider _localizationProvider;
        private SignalBus _signalBus;

        private void Start()
        {
        }

        [Inject]
        public void Initialize(SignalBus signalBus, ILocalizationProvider localizationProvider)
        {
            _signalBus = signalBus;
            _localizationProvider = localizationProvider;
            _signalBus.Subscribe<SignalLocalizationChanged>(s =>
            {
                gameObject.GetComponent<TMP_Text>().text = _localizationProvider.Get(key);
            });
            gameObject.GetComponent<TMP_Text>().text = _localizationProvider.Get(key);
        }
    }
}