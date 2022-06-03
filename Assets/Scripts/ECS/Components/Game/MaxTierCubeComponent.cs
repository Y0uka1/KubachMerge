using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace ECS.Components.Game
{
    [Unique, Game]
    public class MaxTierCubeComponent:IComponent
    {
        public int Value;
    }
}