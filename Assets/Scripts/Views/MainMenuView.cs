using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainMenuView:AView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Text playButtonText;
        [SerializeField] private Button ruLocalizationButton;
        [SerializeField] private Button engLocalizationButton;

        public Button PlayButton => playButton;

        public Text PlayButtonText => playButtonText;

        public Button RuLocalizationButton => ruLocalizationButton;

        public Button EngLocalizationButton => engLocalizationButton;
    }
}