using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "BuildSettings", menuName = "Databases/BuildSettings")]
    public class BuildSettings:ScriptableObject
    {
        [SerializeField] private bool isDebug;

        public bool IsDebug => isDebug;
    }
}