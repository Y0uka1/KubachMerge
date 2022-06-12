using UnityEngine;

namespace Views
{
    public class BattleFieldView:LinkableView<GameEntity>
    {
        [SerializeField] private BattleFieldItemsCollection itemsCollection;

        public BattleFieldItemsCollection ItemsCollection => itemsCollection;
    }
}