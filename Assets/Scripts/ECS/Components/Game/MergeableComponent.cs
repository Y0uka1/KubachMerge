using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace ECS.Components.Game
{
    [Game, Event(EventTarget.Any), Event(EventTarget.Any,EventType.Removed)]
    public class MergeableComponent : IComponent
    { }
}