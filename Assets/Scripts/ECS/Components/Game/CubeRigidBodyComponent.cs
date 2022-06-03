using Entitas;
using UnityEngine;

namespace ECS.Components.Game
{
    [Game]
    public class CubeRigidBodyComponent:IComponent
    {
        public Rigidbody Value;
    }
}