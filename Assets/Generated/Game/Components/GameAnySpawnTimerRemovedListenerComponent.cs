//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnySpawnTimerRemovedListenerComponent anySpawnTimerRemovedListener { get { return (AnySpawnTimerRemovedListenerComponent)GetComponent(GameComponentsLookup.AnySpawnTimerRemovedListener); } }
    public bool hasAnySpawnTimerRemovedListener { get { return HasComponent(GameComponentsLookup.AnySpawnTimerRemovedListener); } }

    public void AddAnySpawnTimerRemovedListener(System.Collections.Generic.List<IAnySpawnTimerRemovedListener> newValue) {
        var index = GameComponentsLookup.AnySpawnTimerRemovedListener;
        var component = (AnySpawnTimerRemovedListenerComponent)CreateComponent(index, typeof(AnySpawnTimerRemovedListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnySpawnTimerRemovedListener(System.Collections.Generic.List<IAnySpawnTimerRemovedListener> newValue) {
        var index = GameComponentsLookup.AnySpawnTimerRemovedListener;
        var component = (AnySpawnTimerRemovedListenerComponent)CreateComponent(index, typeof(AnySpawnTimerRemovedListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnySpawnTimerRemovedListener() {
        RemoveComponent(GameComponentsLookup.AnySpawnTimerRemovedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnySpawnTimerRemovedListener;

    public static Entitas.IMatcher<GameEntity> AnySpawnTimerRemovedListener {
        get {
            if (_matcherAnySpawnTimerRemovedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnySpawnTimerRemovedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnySpawnTimerRemovedListener = matcher;
            }

            return _matcherAnySpawnTimerRemovedListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnySpawnTimerRemovedListener(IAnySpawnTimerRemovedListener value) {
        var listeners = hasAnySpawnTimerRemovedListener
            ? anySpawnTimerRemovedListener.value
            : new System.Collections.Generic.List<IAnySpawnTimerRemovedListener>();
        listeners.Add(value);
        ReplaceAnySpawnTimerRemovedListener(listeners);
    }

    public void RemoveAnySpawnTimerRemovedListener(IAnySpawnTimerRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anySpawnTimerRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnySpawnTimerRemovedListener();
        } else {
            ReplaceAnySpawnTimerRemovedListener(listeners);
        }
    }
}
