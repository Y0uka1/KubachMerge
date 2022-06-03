//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    static readonly ECS.Components.Command.AdInterstitialComponent adInterstitialComponent = new ECS.Components.Command.AdInterstitialComponent();

    public bool isAdInterstitial {
        get { return HasComponent(CommandComponentsLookup.AdInterstitial); }
        set {
            if (value != isAdInterstitial) {
                var index = CommandComponentsLookup.AdInterstitial;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : adInterstitialComponent;

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
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherAdInterstitial;

    public static Entitas.IMatcher<CommandEntity> AdInterstitial {
        get {
            if (_matcherAdInterstitial == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.AdInterstitial);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherAdInterstitial = matcher;
            }

            return _matcherAdInterstitial;
        }
    }
}
