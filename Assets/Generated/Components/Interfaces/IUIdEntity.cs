//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IUIdEntity {

    ECS.Components.BattleGround.UIdComponent uId { get; }
    bool hasUId { get; }

    void AddUId(long newValue);
    void ReplaceUId(long newValue);
    void RemoveUId();
}