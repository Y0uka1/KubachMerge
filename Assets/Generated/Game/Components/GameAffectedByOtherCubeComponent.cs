//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ECS.Components.Game.AffectedByOtherCubeComponent affectedByOtherCubeComponent = new ECS.Components.Game.AffectedByOtherCubeComponent();

    public bool isAffectedByOtherCube {
        get { return HasComponent(GameComponentsLookup.AffectedByOtherCube); }
        set {
            if (value != isAffectedByOtherCube) {
                var index = GameComponentsLookup.AffectedByOtherCube;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : affectedByOtherCubeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAffectedByOtherCube;

    public static Entitas.IMatcher<GameEntity> AffectedByOtherCube {
        get {
            if (_matcherAffectedByOtherCube == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AffectedByOtherCube);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAffectedByOtherCube = matcher;
            }

            return _matcherAffectedByOtherCube;
        }
    }
}