using ConfigurationLibrary.Interfaces.Factories;
using System;
using WebDriverLibrary.Configuration;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.Factories;

namespace WebDriverLibrary.Factories
{
    public class WebDriverConfigurationFactory : IWebDriverConfigurationFactory
    {
        private readonly IConfigurationServiceFactory _configurationServiceFactory;

        public WebDriverConfigurationFactory(IConfigurationServiceFactory configurationServiceFactory)
        {

            _configurationServiceFactory = configurationServiceFactory;
        }

        public IWebDriverConfiguration CreateWebDriverConfiguration(string filePath, string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            var configurationService = _configurationServiceFactory.CreateConfigurationService(filePath, fileName);

            return new WebDriverConfiguration(configurationService);
        }
    }
}
