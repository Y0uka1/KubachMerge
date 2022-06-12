//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BattleGroundEntity {

    static readonly ECS.Components.BattleGround.FighterComponent fighterComponent = new ECS.Components.BattleGround.FighterComponent();

    public bool isFighter {
        get { return HasComponent(BattleGroundComponentsLookup.Fighter); }
        set {
            if (value != isFighter) {
                var index = BattleGroundComponentsLookup.Fighter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : fighterComponent;

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
public sealed partial class BattleGroundMatcher {

    static Entitas.IMatcher<BattleGroundEntity> _matcherFighter;

    public static Entitas.IMatcher<BattleGroundEntity> Fighter {
        get {
            if (_matcherFighter == null) {
                var matcher = (Entitas.Matcher<BattleGroundEntity>)Entitas.Matcher<BattleGroundEntity>.AllOf(BattleGroundComponentsLookup.Fighter);
                matcher.componentNames = BattleGroundComponentsLookup.componentNames;
                _matcherFighter = matcher;
            }

            return _matcherFighter;
        }
    }
}