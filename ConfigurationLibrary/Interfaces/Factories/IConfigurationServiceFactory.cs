using ConfigurationLibrary.Interfaces.Services;

namespace ConfigurationLibrary.Interfaces.Factories;

public interface IConfigurationServiceFactory
{
    IConfigurationService CreateConfigurationService(string filePath, string fileName);
}
