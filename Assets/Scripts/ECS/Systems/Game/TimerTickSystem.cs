using UnityEngine;
using Zenject;

namespace ECS.Systems.Game
{
    public class TimerTickSystem:IFixedTickable
    {
        private readonly GameContext _gameContext;

        public TimerTickSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void FixedTick()
        {
            var entities = _gameContext.GetGroup(GameMatcher.Timer).GetEntities();
            var delta = Time.deltaTime;
            foreach (var entity in entities)
            {
                if (entity.hasSpawnTimer)
                {
                    entity.spawnTimer.Value -= delta;
                    if(entity.spawnTimer.Value<=0)
                        entity.RemoveSpawnTimer();
                }
            }
        }
    }
}