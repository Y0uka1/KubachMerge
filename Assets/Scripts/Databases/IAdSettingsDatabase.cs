namespace Databases
{
    public interface IAdSettingsDatabase
    {
        string BannerAdUnitId { get; }
        string InterstitialAdUnitId { get; }
    }
}