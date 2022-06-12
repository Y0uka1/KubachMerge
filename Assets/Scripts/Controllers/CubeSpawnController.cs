using System;
using Databases;
using Extensions;
using UnityEngine;
using Views;
using Zenject;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class CubeSpawnController : AController<BoardView>, ITickable, IInitializable, IAnySpawnTimerRemovedListener
    {
        private readonly ICubesMeshesDatabase _cubesMeshesDatabase;
        private readonly GameContext _gameContext;
        private readonly ICubesColorsDatabase _cubesColorsDatabase;
        private readonly CommandContext _commandContext;
        // private GameEntity _timerEntity;
        private int spawnedCubesCounter = 0;

        public CubeSpawnController(ICubesMeshesDatabase cubesMeshesDatabase, GameContext gameContext,
            BoardView boardView, ICubesColorsDatabase cubesColorsDatabase, CommandContext commandContext) : base(boardView)
        {
            _cubesMeshesDatabase = cubesMeshesDatabase;
            _gameContext = gameContext;
            _cubesColorsDatabase = cubesColorsDatabase;
            _commandContext = commandContext;
        }

        public void Initialize()
        {
            _gameContext.SetMaxTierCube(1);
            _gameContext.SetScore(0);
            var entity = _gameContext.CreateEntity();
            entity.AddAnySpawnTimerRemovedListener(this);
            View.Link(entity);
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.S))
                SpawnDefaultCube();
        }

        public void SpawnDefaultCube()
        {
            var cubeView = UnityEngine.Object.Instantiate(_cubesMeshesDatabase.Get(null),
                View.SpawnPosition.position, Quaternion.identity);
            int cubeTier = 1;
            if(_gameContext.maxTierCube.Value>2)
                cubeTier = Random.Range(1, _gameContext.maxTierCube.Value);
            var entity = _gameContext.CreateCube(cubeTier, cubeView, View.SpawnPosition.position);
            entity.cubeRenderer.Value.material.color = _cubesColorsDatabase.Get(cubeTier);
            entity.cubeRigidBody.Value.constraints = RigidbodyConstraints.FreezePositionY;
            entity.cubeRigidBody.Value.freezeRotation = true;
            entity.isUnderControl = true;
            spawnedCubesCounter++;
            if (spawnedCubesCounter >= 20)
            {
                _commandContext.CreateEntity().isAdInterstitial = true;
                spawnedCubesCounter = 0;
            }
        }

        public void OnAnySpawnTimerRemoved(GameEntity entity)
        {
            SpawnDefaultCube();
        }
    }
}