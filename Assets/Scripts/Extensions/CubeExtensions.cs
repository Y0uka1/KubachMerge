using Databases;
using UnityEngine;
using Views;
using Zenject;

namespace Extensions
{
    public static class CubeExtensions
    {
        private static long UId = 0;
        public static GameEntity CreateCube(this GameContext context, int tier, CubeView cubeView, Vector3 position)
        {
            var entity = context.CreateEntity();
            entity.AddTier(tier);
            entity.AddUId(++UId);
            // entity.isMergeable = true;
            cubeView.Link(entity);
            return entity;
        }

        public static BattleGroundEntity CreateFighter(this BattleGroundContext context, GameEntity gameEntity,
            BattleFieldItemView fighterView)
        {
            var entity = context.CreateEntity();
            entity.AddUId(gameEntity.uId.Value);
            fighterView.Link(entity);
            return entity;
        }
    }
}