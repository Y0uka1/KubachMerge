using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BattleFieldItemView:LinkableView<BattleGroundEntity>
    {
        public long UId => Entity.uId.Value;
        [SerializeField] private Image Icon;

        public void SetIcon(Sprite sprite)
        {
            Icon.sprite = sprite;
        }
    }
}