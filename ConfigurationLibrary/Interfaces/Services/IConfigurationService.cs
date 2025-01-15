using Microsoft.Extensions.Configuration;

namespace ConfigurationLibrary.Interfaces.Services;

public interface IConfigurationService
{
    IConfiguration GetConfiguration();
    T GetConfigurationSection<T>(string sectionName) where T : class;
    T GetConfigurationValue<T>(string key);
}
