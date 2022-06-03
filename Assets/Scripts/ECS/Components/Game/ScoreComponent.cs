using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace ECS.Components.Game
{
    [Unique, Game, Event(EventTarget.Any)]
    public class ScoreComponent:IComponent
    {
        public long Value;
    }
}