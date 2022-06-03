namespace Databases
{
    public interface ITimeSettingsDatabase
    {
        float CubeSpawnDelayS { get; }
        float LooseTimerS { get; }
    }
}