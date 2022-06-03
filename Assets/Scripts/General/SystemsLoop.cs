using Entitas;
using Zenject;

namespace General
{
    public class SystemsLoop:IInitializable, ITickable
    {
        private readonly Systems _systems;

        public SystemsLoop(Systems systems)
        {
            _systems = systems;
        }

        public void Initialize()
        {
            _systems.Initialize();
        }

        public void Tick()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}