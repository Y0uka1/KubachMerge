using DefaultNamespace;

namespace Databases
{
    public interface ILocalizationProvider
    {
        void SwitchLocalization(ELocalizationLanguage language);
        string Get(string key);
    }
}