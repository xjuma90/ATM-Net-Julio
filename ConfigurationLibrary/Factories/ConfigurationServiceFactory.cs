using ConfigurationLibrary.Interfaces.Factories;
using ConfigurationLibrary.Interfaces.Services;
using ConfigurationLibrary.Services;

namespace ConfigurationLibrary.Factories;

public class ConfigurationServiceFactory : IConfigurationServiceFactory
{
    public IConfigurationService CreateConfigurationService(string filePath, string fileName)
    {
        return new ConfigurationService(filePath, fileName);
    }
}
