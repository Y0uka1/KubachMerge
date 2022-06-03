using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(fileName = "MockAdSettingsDatabase", menuName = "Databases/MockAdSettingsDatabase")]
    public class MockAdSettingsDatabase:ScriptableObject, IAdSettingsDatabase
    {
        [SerializeField] private string bannerAdUnitId;
        [SerializeField] private string interstitialAdUnitId;

        public string BannerAdUnitId => bannerAdUnitId;

        public string InterstitialAdUnitId => interstitialAdUnitId;
    }
}