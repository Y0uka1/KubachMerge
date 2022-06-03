using Controllers;
using Databases;
using Debug;
using ECS.Systems.Game;
using Entitas;
using Extensions;
using GoogleMobileAds.Api;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;
using Views;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimerTickSystem>().AsSingle();
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<LocalizationProvider>().AsSingle();
        Container.DeclareSignal<SignalLocalizationChanged>();
    }

    [Inject]
    private void BindSystems(Systems systems, GameEventSystems gameEventSystems, params ISystem[] bindableSystems)
    {
        for (int i = 1; i < bindableSystems.Length; i++)
        {
            systems.Add(bindableSystems[i]);
        }

        systems.Add(gameEventSystems);
    }
}