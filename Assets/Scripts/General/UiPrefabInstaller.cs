using Controllers;
using Entitas.Unity;
using UnityEngine;
using Views;
using Zenject;

namespace General
{
    public class UiPrefabInstaller:MonoInstaller
    {
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private MainMenuView mainMenuView;
        public override void InstallBindings()
        {
            Transform parent = Container.InstantiatePrefab(mainCanvas).transform;
            // Container.InstantiatePrefab(scoreView).transform.SetParent(parent, false);
            var score = Instantiate(scoreView, parent); 
            Container.Bind<ScoreView>().FromInstance(score).AsSingle();
            var mainMenu = Instantiate(mainMenuView, parent);
            Container.Bind<MainMenuView>().FromInstance(mainMenu).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreController>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle();
        }


    }
}