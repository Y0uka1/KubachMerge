using Entitas;
using UnityEngine;

namespace ECS.Components.Game
{
    [Game]
    public class CubePositionComponent:IComponent
    {
        public Transform Value;
    }
}