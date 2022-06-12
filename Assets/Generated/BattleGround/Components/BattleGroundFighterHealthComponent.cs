//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BattleGroundEntity {

    public ECS.Components.BattleGround.FighterHealthComponent fighterHealth { get { return (ECS.Components.BattleGround.FighterHealthComponent)GetComponent(BattleGroundComponentsLookup.FighterHealth); } }
    public bool hasFighterHealth { get { return HasComponent(BattleGroundComponentsLookup.FighterHealth); } }

    public void AddFighterHealth(long newValue) {
        var index = BattleGroundComponentsLookup.FighterHealth;
        var component = (ECS.Components.BattleGround.FighterHealthComponent)CreateComponent(index, typeof(ECS.Components.BattleGround.FighterHealthComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFighterHealth(long newValue) {
        var index = BattleGroundComponentsLookup.FighterHealth;
        var component = (ECS.Components.BattleGround.FighterHealthComponent)CreateComponent(index, typeof(ECS.Components.BattleGround.FighterHealthComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFighterHealth() {
        RemoveComponent(BattleGroundComponentsLookup.FighterHealth);
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

    static Entitas.IMatcher<BattleGroundEntity> _matcherFighterHealth;

    public static Entitas.IMatcher<BattleGroundEntity> FighterHealth {
        get {
            if (_matcherFighterHealth == null) {
                var matcher = (Entitas.Matcher<BattleGroundEntity>)Entitas.Matcher<BattleGroundEntity>.AllOf(BattleGroundComponentsLookup.FighterHealth);
                matcher.componentNames = BattleGroundComponentsLookup.componentNames;
                _matcherFighterHealth = matcher;
            }

            return _matcherFighterHealth;
        }
    }
}
