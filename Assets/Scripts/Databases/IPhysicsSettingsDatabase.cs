namespace Databases
{
    public interface IPhysicsSettingsDatabase
    {
        float CubeStartingAcceleration { get; }
        float CubeMergingAcceleration { get; }
        
        float CubeMagneticAcceleration { get; }
    }
}