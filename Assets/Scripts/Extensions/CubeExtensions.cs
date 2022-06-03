using Databases;
using UnityEngine;
using Views;
using Zenject;

namespace Extensions
{
    public static class CubeExtensions
    {
        public static GameEntity CreateCube(this GameContext context, int tier, CubeView cubeView, Vector3 position)
        {
            var entity = context.CreateEntity();
            entity.AddTier(tier);
            entity.isMergeable = true;
            cubeView.Link(entity);
            return entity;
        }
    }
}