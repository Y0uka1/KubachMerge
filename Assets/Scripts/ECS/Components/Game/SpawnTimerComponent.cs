using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace ECS.Components.Game
{
    [Game, Event(EventTarget.Any,EventType.Removed)]
    public class SpawnTimerComponent:IComponent
    {
        public float Value;
    }
}