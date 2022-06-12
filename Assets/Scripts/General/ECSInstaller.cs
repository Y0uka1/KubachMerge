using Debug;
using ECS.Systems;
using ECS.Systems.Game;
using Entitas;
using Zenject;

namespace General
{
    public class ECSInstaller: MonoInstaller
    {
        [Inject] private BuildSettings _buildSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(Contexts.sharedInstance).AsSingle();
            Container.BindInstance(Contexts.sharedInstance.game).AsSingle();
            Container.BindInstance(Contexts.sharedInstance.command).AsSingle();
            Container.BindInstance(Contexts.sharedInstance.battleGround).AsSingle();
            // Container.Bind().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.BindInterfacesAndSelfTo<Systems>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEventSystems>().AsSingle();
            if(_buildSettings.IsDebug)
                Container.BindInterfacesAndSelfTo<DebugHotKeysSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemsLoop>().AsSingle();
            Container.BindInterfacesAndSelfTo<MergeCollisionSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ControllRemovedSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CubeStartingAccelerationSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CubeAffectedByOtherCubeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MergeSystem>().AsSingle();
            
            if(_buildSettings.IsAdvertismentActive)
            {
                Container.BindInterfacesAndSelfTo<AdInterstitialSystem>().AsSingle();
                Container.BindInterfacesAndSelfTo<AdBannerSystem>().AsSingle();
            }
            
            
            
            Container.BindInterfacesAndSelfTo<DestroySystem>().AsSingle();
        }
    }
}