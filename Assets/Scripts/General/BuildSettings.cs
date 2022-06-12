using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "BuildSettings", menuName = "Databases/BuildSettings")]
    public class BuildSettings:ScriptableObject
    {
        [SerializeField] private bool isDebug;
        [SerializeField] private bool isAdvertismentActive;

        public bool IsAdvertismentActive => isAdvertismentActive;

        public bool IsDebug => isDebug;
    }
}