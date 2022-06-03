using System;
using System.Collections.Generic;
using Entitas;

namespace ECS.Systems
{
    public class DestroySystem:ICleanupSystem
    {
        private readonly GameContext _gameContext;
        private readonly CommandContext _commandContext;

        public DestroySystem(GameContext gameContext, CommandContext commandContext)
        {
            _gameContext = gameContext;
            _commandContext = commandContext;
        }

        public void Cleanup()
        {
            var gameEntities = _gameContext.GetGroup(GameMatcher.Destroyed).GetEntities();
            foreach (var entity in gameEntities)
            {
                entity.Destroy();
            }
            var commandEntities = _commandContext.GetGroup(CommandMatcher.Destroyed).GetEntities();
            foreach (var entity in commandEntities)
            {
                entity.Destroy();
            }
        }
    }
}