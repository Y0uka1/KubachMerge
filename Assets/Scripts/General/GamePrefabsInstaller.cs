using Controllers;
using Entitas;
using UnityEngine;
using Views;
using Zenject;

public class GamePrefabsInstaller : MonoInstaller
{
    [SerializeField] private CubeView _cubeView;
    [SerializeField] private BoardView _boardView;
    [SerializeField] private BattleFieldView battleFieldView;

    public override void InstallBindings()
    {
        BindView<BoardView, CubeSpawnController>(_boardView);
        BindView<BattleFieldView,BattleFieldController>(battleFieldView, _boardView.BattleCanvasPosition);
        // Container.BindInterfacesAndSelfTo<BoardView>().FromComponentInNewPrefab(_boardView).AsSingle();
        // Container.BindInterfacesAndSelfTo<CubeSpawnController>().AsSingle();
    }
    
    private void BindView<TView, TController>(TView view)
        where TView : LinkableView<GameEntity> where TController : IController
    {
        var instantiatedView = Instantiate(view);
        Container.Bind<TView>().FromInstance(instantiatedView).AsSingle();
        Container.BindInterfacesAndSelfTo<TController>().AsSingle();
    }
    private void BindView<TView, TController>(TView view, Transform parent)
        where TView : LinkableView<GameEntity> where TController : IController
    {
        var instantiatedView = Instantiate(view, parent.position, parent.rotation);
        Container.Bind<TView>().FromInstance(instantiatedView).AsSingle();
        Container.BindInterfacesAndSelfTo<TController>().AsSingle();
    }
}