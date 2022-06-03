using System;
using System.Collections.Generic;
using Databases;
using Entitas;
using Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ECS.Systems
{
    public class MergeSystem : ReactiveSystem<CommandEntity>
    {
        private readonly ICubesMeshesDatabase _cubesMeshesDatabase;
        private readonly GameContext _gameContext;
        private readonly ICubesColorsDatabase _cubesColorsDatabase;
        private readonly IPhysicsSettingsDatabase _physicsSettingsDatabase;

        public MergeSystem(CommandContext context, ICubesMeshesDatabase cubesMeshesDatabase, GameContext gameContext,
            ICubesColorsDatabase cubesColorsDatabase, IPhysicsSettingsDatabase physicsSettingsDatabase) : base(context)
        {
            _cubesMeshesDatabase = cubesMeshesDatabase;
            _gameContext = gameContext;
            _cubesColorsDatabase = cubesColorsDatabase;
            _physicsSettingsDatabase = physicsSettingsDatabase;
        }

        protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
        {
            return context.CreateCollector(CommandMatcher.Merge);
        }

        protected override bool Filter(CommandEntity entity)
        {
            return !entity.isDestroyed && entity.hasMerge;
        }

        protected override void Execute(List<CommandEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isDestroyed = true;
                var view = Object.Instantiate(_cubesMeshesDatabase.Get(null), entity.merge.Value.Position,
                    Quaternion.identity);
                var newEntity = _gameContext.CreateCube(entity.merge.Value.Tier, view
                    , entity.merge.Value.Position);
                newEntity.cubeRenderer.Value.material.color = _cubesColorsDatabase.Get(newEntity.tier.Value);
                var accelerationVector = Vector3.up * _physicsSettingsDatabase.CubeMergingAcceleration;
                var cubesGroup = _gameContext.GetGroup(GameMatcher.Mergeable).GetEntities();
                foreach (var cube in cubesGroup)
                {
                    if (cube.tier.Value == newEntity.tier.Value && cube != newEntity && !cube.isUnderControl)
                    {
                        var mergeableCubeposition = cube.cubePosition.Value.position;
                        accelerationVector = newEntity.cubePosition.Value.position + new Vector3(
                            mergeableCubeposition.x *
                            _physicsSettingsDatabase.CubeMagneticAcceleration,
                            _physicsSettingsDatabase.CubeMergingAcceleration,
                            mergeableCubeposition.z *
                            _physicsSettingsDatabase.CubeMagneticAcceleration);
                    }
                }

                if (newEntity.tier.Value > _gameContext.maxTierCube.Value)
                    _gameContext.maxTierCube.Value = newEntity.tier.Value;
                newEntity.cubeRigidBody.Value.AddForce(accelerationVector, ForceMode.Impulse);
                _gameContext.ReplaceScore(_gameContext.score.Value += (long)Math.Pow(2, newEntity.tier.Value));
            }
        }
    }
}