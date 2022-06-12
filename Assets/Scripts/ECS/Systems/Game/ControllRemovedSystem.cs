using System;
using System.Collections.Generic;
using Entitas;

namespace ECS.Systems.Game
{
    public class ControllRemovedSystem:ReactiveSystem<GameEntity>
    {
        public ControllRemovedSystem(GameContext context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.UnderControl.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isDestroyed && !entity.isUnderControl && entity.hasCubeRigidBody;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.cubeRigidBody.Value.freezeRotation = false;
                entity.isMergeable = true;
            }
        }
    }
}