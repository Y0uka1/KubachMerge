using UnityEngine;

namespace Databases
{
    [CreateAssetMenu (fileName = "TimeSettingsDatabase", menuName = "Databases/TimeSettingsDatabase")]
    public class TimeSettingsDatabase:ScriptableObject, ITimeSettingsDatabase
    {
        [SerializeField] private float cubeSpawnDelayS;
        [SerializeField] private float looseTimerS;

        public float CubeSpawnDelayS => cubeSpawnDelayS;

        public float LooseTimerS => looseTimerS;
    }
}