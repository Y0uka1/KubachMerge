using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(fileName = "PhysicsSettingsDatabase", menuName = "Databases/PhysicsSettingsDatabase")]
    public class PhysicsSettingsDatabase:ScriptableObject, IPhysicsSettingsDatabase
    {
        [SerializeField] private float cubeStartingAcceleration;
        [SerializeField] private float cubeMergingAcceleration;
        [SerializeField] private float cubeMagneticAcceleration;

        public float CubeStartingAcceleration => cubeStartingAcceleration;

        public float CubeMergingAcceleration => cubeMergingAcceleration;
        public float CubeMagneticAcceleration => cubeMagneticAcceleration;
    }
}