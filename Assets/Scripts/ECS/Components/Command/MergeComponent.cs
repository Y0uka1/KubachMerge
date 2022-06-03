using Entitas;
using UnityEngine;

namespace ECS.Components.Command
{
    [Command]
    public class MergeComponent:IComponent
    {
        public MergeInfoVo Value;
    }

    public class MergeInfoVo
    {
        public Vector3 Position;
        public int Tier;
    }
}