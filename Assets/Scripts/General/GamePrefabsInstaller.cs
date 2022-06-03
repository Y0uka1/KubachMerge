using Controllers;
using UnityEngine;
using Views;
using Zenject;

public class GamePrefabsInstaller : MonoInstaller
{
    [SerializeField] private CubeView _cubeView;
    [SerializeField] private BoardView _boardView;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BoardView>().FromComponentInNewPrefab(_boardView).AsSingle();
        Container.BindInterfacesAndSelfTo<CubeSpawnController>().AsSingle();
    }
}