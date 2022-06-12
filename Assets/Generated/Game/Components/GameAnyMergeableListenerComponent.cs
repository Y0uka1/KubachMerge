//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyMergeableListenerComponent anyMergeableListener { get { return (AnyMergeableListenerComponent)GetComponent(GameComponentsLookup.AnyMergeableListener); } }
    public bool hasAnyMergeableListener { get { return HasComponent(GameComponentsLookup.AnyMergeableListener); } }

    public void AddAnyMergeableListener(System.Collections.Generic.List<IAnyMergeableListener> newValue) {
        var index = GameComponentsLookup.AnyMergeableListener;
        var component = (AnyMergeableListenerComponent)CreateComponent(index, typeof(AnyMergeableListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyMergeableListener(System.Collections.Generic.List<IAnyMergeableListener> newValue) {
        var index = GameComponentsLookup.AnyMergeableListener;
        var component = (AnyMergeableListenerComponent)CreateComponent(index, typeof(AnyMergeableListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyMergeableListener() {
        RemoveComponent(GameComponentsLookup.AnyMergeableListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyMergeableListener;

    public static Entitas.IMatcher<GameEntity> AnyMergeableListener {
        get {
            if (_matcherAnyMergeableListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyMergeableListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyMergeableListener = matcher;
            }

            return _matcherAnyMergeableListener;
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

    public void AddAnyMergeableListener(IAnyMergeableListener value) {
        var listeners = hasAnyMergeableListener
            ? anyMergeableListener.value
            : new System.Collections.Generic.List<IAnyMergeableListener>();
        listeners.Add(value);
        ReplaceAnyMergeableListener(listeners);
    }

    public void RemoveAnyMergeableListener(IAnyMergeableListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyMergeableListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyMergeableListener();
        } else {
            ReplaceAnyMergeableListener(listeners);
        }
    }
}