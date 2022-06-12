using Databases;
using Entitas;
using Extensions;
using UnityEngine;
using Views;
using Zenject;

namespace Controllers
{
    public class BattleFieldController : AController<BattleFieldView>, IAnyMergeableListener,
        IAnyMergeableRemovedListener
    {
        private readonly GameContext _gameContext;
        private readonly BattleGroundContext _battleGroundContext;
        private readonly IFightersColorsDatabase _fightersColorsDatabase;

        public BattleFieldController(BattleFieldView view, GameContext gameContext,
            BattleGroundContext battleGroundContext, IFightersColorsDatabase fightersColorsDatabase) : base(view)
        {
            _gameContext = gameContext;
            _battleGroundContext = battleGroundContext;
            _fightersColorsDatabase = fightersColorsDatabase;
        }

        public override void Initialize()
        {
            base.Initialize();
            var battlefieldEntity = _gameContext.CreateEntity();
            View.Link(battlefieldEntity);
            battlefieldEntity.AddAnyMergeableListener(this);
            battlefieldEntity.AddAnyMergeableRemovedListener(this);
        }

        public void OnAnyMergeable(GameEntity entity)
        {
            UnityEngine.Debug.Log("Mergeable Added");
            var item = View.ItemsCollection.Add();
            var fighterEntity = _battleGroundContext.CreateFighter(entity, item);
            fighterEntity.AddFighterHealth(100);
            fighterEntity.AddFighterDamage(100);
            item.SetIcon(_fightersColorsDatabase.Get(entity.tier.Value));
        }

        public void OnAnyMergeableRemoved(GameEntity entity)
        {
            var collection = View.ItemsCollection.Get();
            for (int i = 0; i < View.ItemsCollection.Count(); i++)
            {
                if (collection[i].UId != entity.uId.Value)
                    continue;
                Object.Destroy(collection[i].gameObject);
                return;
            }
        }
    }
}