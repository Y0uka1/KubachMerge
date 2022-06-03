//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity maxTierCubeEntity { get { return GetGroup(GameMatcher.MaxTierCube).GetSingleEntity(); } }
    public ECS.Components.Game.MaxTierCubeComponent maxTierCube { get { return maxTierCubeEntity.maxTierCube; } }
    public bool hasMaxTierCube { get { return maxTierCubeEntity != null; } }

    public GameEntity SetMaxTierCube(int newValue) {
        if (hasMaxTierCube) {
            throw new Entitas.EntitasException("Could not set MaxTierCube!\n" + this + " already has an entity with ECS.Components.Game.MaxTierCubeComponent!",
                "You should check if the context already has a maxTierCubeEntity before setting it or use context.ReplaceMaxTierCube().");
        }
        var entity = CreateEntity();
        entity.AddMaxTierCube(newValue);
        return entity;
    }

    public void ReplaceMaxTierCube(int newValue) {
        var entity = maxTierCubeEntity;
        if (entity == null) {
            entity = SetMaxTierCube(newValue);
        } else {
            entity.ReplaceMaxTierCube(newValue);
        }
    }

    public void RemoveMaxTierCube() {
        maxTierCubeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ECS.Components.Game.MaxTierCubeComponent maxTierCube { get { return (ECS.Components.Game.MaxTierCubeComponent)GetComponent(GameComponentsLookup.MaxTierCube); } }
    public bool hasMaxTierCube { get { return HasComponent(GameComponentsLookup.MaxTierCube); } }

    public void AddMaxTierCube(int newValue) {
        var index = GameComponentsLookup.MaxTierCube;
        var component = (ECS.Components.Game.MaxTierCubeComponent)CreateComponent(index, typeof(ECS.Components.Game.MaxTierCubeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxTierCube(int newValue) {
        var index = GameComponentsLookup.MaxTierCube;
        var component = (ECS.Components.Game.MaxTierCubeComponent)CreateComponent(index, typeof(ECS.Components.Game.MaxTierCubeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxTierCube() {
        RemoveComponent(GameComponentsLookup.MaxTierCube);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxTierCube;

    public static Entitas.IMatcher<GameEntity> MaxTierCube {
        get {
            if (_matcherMaxTierCube == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxTierCube);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxTierCube = matcher;
            }

            return _matcherMaxTierCube;
        }
    }
}
