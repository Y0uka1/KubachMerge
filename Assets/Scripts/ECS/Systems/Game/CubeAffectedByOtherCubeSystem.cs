using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace ECS.Systems.Game
{
    public class CubeAffectedByOtherCubeSystem:ReactiveSystem<GameEntity>
    {
        public CubeAffectedByOtherCubeSystem(GameContext context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AffectedByOtherCube.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isDestroyed && entity.isAffectedByOtherCube && entity.hasCubeRigidBody;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.cubeRigidBody.Value.freezeRotation = false;
                entity.cubeRigidBody.Value.constraints = RigidbodyConstraints.None;
            }
        }
    }
}