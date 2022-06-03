using Entitas;
using UnityEngine;

namespace ECS.Components.Game
{
    [Game]
    public class CubeRendererComponent:IComponent
    {
        public MeshRenderer Value;
    }
}