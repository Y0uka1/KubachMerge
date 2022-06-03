using System;
using System.Collections.Generic;
using Databases;
using Entitas;
using Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Debug
{
    public class DebugHotKeysSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private ICubesMeshesDatabase _cubesMeshesDatabase;
        private readonly CommandContext _commandContext;

        public DebugHotKeysSystem(GameContext gameContext, ICubesMeshesDatabase cubesMeshesDatabase,
            CommandContext commandContext)
        {
            _gameContext = gameContext;
            _cubesMeshesDatabase = cubesMeshesDatabase;
            _commandContext = commandContext;
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.S))
                SpawnDefaultCube();

            if (Input.GetKeyDown(KeyCode.B))
                _commandContext.CreateEntity().isAdBanner = true;

            if (Input.GetKeyDown(KeyCode.I))
                _commandContext.CreateEntity().isAdInterstitial = true;

            if (Input.GetKeyDown(KeyCode.J))
            {
                var localization = Resources.Load<TextAsset>($"Localization/ENG");
                var a = JsonUtility.FromJson<LocalizationJson>(localization.text);
            }
        }

        private void SpawnDefaultCube()
        {
            var cubeView = Object.Instantiate(_cubesMeshesDatabase.Get(null));
            _gameContext.CreateCube(1, cubeView, Vector3.zero);
            UnityEngine.Debug.Log("Pepega");
        }
    }
}