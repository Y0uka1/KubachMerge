using Databases;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace General
{
    [CreateAssetMenu(fileName = "GameDatabasesInstaller", menuName = "Installers/GameDatabasesInstaller")]
    public class GameDatabasesInstaller:ScriptableObjectInstaller<GameDatabasesInstaller>
    {
        [SerializeField] private CubesMeshesDatabase cubesMeshesDatabase;
        [SerializeField] private CubesColorsDatabase cubesColorsDatabase;
        [SerializeField] private PhysicsSettingsDatabase physicsSettingsDatabase;
        [SerializeField] private TimeSettingsDatabase timeSettingsDatabase;
        [SerializeField] private MockAdSettingsDatabase mockAdSettingsDatabase;
        [SerializeField] private FightersColorsDatabase fightersColorsDatabase;
        [SerializeField] private BuildSettings buildSettings;
        public override void InstallBindings()
        {
            Container.Bind<BuildSettings>().FromInstance(buildSettings).AsSingle();
            Container.Bind<ICubesMeshesDatabase>().FromInstance(cubesMeshesDatabase).AsSingle();
            Container.Bind<ICubesColorsDatabase>().FromInstance(cubesColorsDatabase).AsSingle();
            Container.Bind<IPhysicsSettingsDatabase>().FromInstance(physicsSettingsDatabase).AsSingle();
            Container.Bind<ITimeSettingsDatabase>().FromInstance(timeSettingsDatabase).AsSingle();
            Container.Bind<IAdSettingsDatabase>().FromInstance(mockAdSettingsDatabase).AsSingle();
            Container.Bind<IFightersColorsDatabase>().FromInstance(fightersColorsDatabase).AsSingle();
        }
    }
}