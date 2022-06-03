using System;
using System.Collections.Generic;
using Databases;
using Entitas;
using UnityEngine;
using Zenject;

namespace ECS.Systems.Game
{
    public class CubeStartingAccelerationSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _context;
        private readonly IPhysicsSettingsDatabase _physicsSettingsDatabase;
        private readonly ITimeSettingsDatabase _timeSettingsDatabase;

        public CubeStartingAccelerationSystem(GameContext context, IPhysicsSettingsDatabase physicsSettingsDatabase,
            ITimeSettingsDatabase timeSettingsDatabase) : base(context)
        {
            _context = context;
            _physicsSettingsDatabase = physicsSettingsDatabase;
            _timeSettingsDatabase = timeSettingsDatabase;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.StartingAcceleration.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isDestroyed && entity.isStartingAcceleration && entity.hasCubeRigidBody;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.cubeRigidBody.Value.AddForce(Vector3.left * _physicsSettingsDatabase.CubeStartingAcceleration,
                    ForceMode.Impulse);
                entity.isStartingAcceleration = false;
                var timer = _context.CreateEntity();
                timer.AddSpawnTimer(_timeSettingsDatabase.CubeSpawnDelayS);
                timer.isTimer = true;
            }
        }
    }
}