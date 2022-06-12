using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScoreView:LinkableView<GameEntity>,IAnyScoreListener
    {
        [SerializeField] private TMP_Text scoreTextValue;
        [SerializeField] private TMP_Text scoreText;

        public TMP_Text ScoreText => scoreText;

        public override void Link(GameEntity entity)
        {
            entity.AddAnyScoreListener(this);
            base.Link(entity);
        }

        public void OnAnyScore(GameEntity entity, long value)
        {
            scoreTextValue.text = value.ToString();
        }
    }
}