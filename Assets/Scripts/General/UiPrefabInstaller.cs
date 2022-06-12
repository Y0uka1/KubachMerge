using Controllers;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Views;
using Zenject;

namespace General
{
    public class UiPrefabInstaller : MonoInstaller
    {
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private BattleFieldView battleFieldView;
        private Transform _parent;

        public override void InstallBindings()
        {
            _parent = Container.InstantiatePrefab(mainCanvas).transform;
            // Container.InstantiatePrefab(scoreView).transform.SetParent(parent, false);
            BindUiView<ScoreView,ScoreController>(scoreView);
            BindUiView<MainMenuView,MainMenuController>(mainMenuView);
            // BindUiView<BattleFieldView,BattleFieldController>(battleFieldView);
        }

        
        private void BindUiView<TView, TController>(TView view)
            where TView : LinkableView<GameEntity> where TController : IController
        {
            var instantiatedView = Instantiate(view, _parent);
            Container.Bind<TView>().FromInstance(instantiatedView).AsSingle();
            Container.BindInterfacesAndSelfTo<TController>().AsSingle();
        }
    }
}