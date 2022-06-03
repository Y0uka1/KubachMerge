using System;
using System.Collections.Generic;
using ECS.Components.Command;
using ECS.Components.Game;
using Entitas;
using Extensions;

namespace ECS.Systems.Game
{
    public class MergeCollisionSystem : ReactiveSystem<GameEntity>
    {
        private readonly CommandContext _commandContext;
        private readonly List<CollisionPairVo> collisionPairPool = new List<CollisionPairVo>();

        public MergeCollisionSystem(GameContext context, CommandContext commandContext) : base(context)
        {
            _commandContext = commandContext;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCollision && !entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isDestroyed = true;
                entity.collision.Value.LinkedEntity.isDestroyed = true;
                var command = _commandContext.CreateEntity();
                if(!PoolContainsPair(entity,entity.collision.Value.LinkedEntity))
                    continue;
                command.AddMerge(new MergeInfoVo()
                {
                    Position = entity.collision.Position,
                    Tier = entity.tier.Value + 1
                });
            }
        }

        private bool PoolContainsPair(GameEntity firstEntity, GameEntity secondEntity)
        {
            var pair = new CollisionPairVo()
            {
                firstElement = firstEntity,
                secondElement = secondEntity
            };
            var invertedPair = new CollisionPairVo()
            {
                firstElement = secondEntity,
                secondElement = firstEntity
            };

            for(int i=0;i<collisionPairPool.Count;i++)
            {
                var pairVo = collisionPairPool[i];
                if (pairVo.firstElement == pair.firstElement && pairVo.secondElement == pair.secondElement)
                {
                    collisionPairPool.Remove(pairVo);
                    return true;
                }

                if (pairVo.firstElement == invertedPair.firstElement || pairVo.secondElement == invertedPair.secondElement)
                {
                    collisionPairPool.Remove(invertedPair);
                    return true;
                }
            }
            
            collisionPairPool.Add(pair);
            return false;
        }
    }
}