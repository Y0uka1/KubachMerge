using System;
using Databases;
using DefaultNamespace;
using Extensions;
using Signals;
using UniRx;
using Views;
using Zenject;

namespace Controllers
{
    public class MainMenuController : AController<MainMenuView>, ILocalizable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly ILocalizationProvider _localizationProvider;
        private readonly CubeSpawnController _spawnController;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public MainMenuController(MainMenuView view, SignalBus signalBus, ILocalizationProvider localizationProvider,
            CubeSpawnController spawnController) : base(view)
        {
            _signalBus = signalBus;
            _localizationProvider = localizationProvider;
            _spawnController = spawnController;
        }

        public override void Initialize()
        {
            View.PlayButton.OnClickAsObservable().Subscribe(s =>
                {
                    //TODO Need Refactor
                    View.gameObject.SetActive(false);
                    _spawnController.SpawnDefaultCube();
                })
                .AddTo(_disposable);
            View.EngLocalizationButton.OnClickAsObservable().Subscribe(s =>
            {
                _localizationProvider.SwitchLocalization(ELocalizationLanguage.ENG);
            }).AddTo(_disposable);
            View.RuLocalizationButton.OnClickAsObservable().Subscribe(s =>
            {
                _localizationProvider.SwitchLocalization(ELocalizationLanguage.RU);
            }).AddTo(_disposable);
            Listen();
        }

        public void Listen()
        {
            _signalBus.Subscribe<SignalLocalizationChanged>(s => { SetText(); });
        }

        public void SetText()
        {
            //TODO Need Refactor
            View.PlayButtonText.text = _localizationProvider.Get("Ui.Button.Play");
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}