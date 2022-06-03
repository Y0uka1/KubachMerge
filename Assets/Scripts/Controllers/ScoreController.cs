using Databases;
using Extensions;
using Signals;
using Views;
using Zenject;

namespace Controllers
{
    public class ScoreController:AController<ScoreView>, ILocalizable
    {
        private readonly GameContext _gameContext;
        private readonly SignalBus _signalBus;
        private readonly ILocalizationProvider _localizationProvider;

        public ScoreController(ScoreView scoreView, GameContext gameContext, SignalBus signalBus, ILocalizationProvider localizationProvider) : base(scoreView)
        {
            _gameContext = gameContext;
            _signalBus = signalBus;
            _localizationProvider = localizationProvider;
        }

        public override void Initialize()
        {
            var entity = _gameContext.CreateEntity();
            Listen();
            View.Link(entity);
        }

        public void Listen()
        {
            _signalBus.Subscribe<SignalLocalizationChanged>(s=>SetText());
        }

        public void SetText()
        {
            //TODO Need refactor
            View.ScoreText.text = _localizationProvider.Get("Ui.Panel.Score");
        }
    }
}