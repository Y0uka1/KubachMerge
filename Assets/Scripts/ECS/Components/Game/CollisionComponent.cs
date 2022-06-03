using Entitas;
using UnityEngine;
using Views;

namespace ECS.Components.Game
{
    [Game]
    public class CollisionComponent:IComponent
    {
        public CubeView Value;
        public Vector3 Position;
    }
}