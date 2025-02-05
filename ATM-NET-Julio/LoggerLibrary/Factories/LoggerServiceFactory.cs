using ConfigurationLibrary.Interfaces.Factories;
using LoggerLibrary.Interfaces.Factories;
using LoggerLibrary.Interfaces.Services;
using LoggerLibrary.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LoggerLibrary.Factories
{
    public class LoggerServiceFactory : ILoggerServiceFactory
    {
        private const string _serilogConfigKey = "Serilog";

        private readonly IConfigurationServiceFactory _configurationServiceFactory;

        public LoggerServiceFactory(IConfigurationServiceFactory configurationServiceFactory)
        {
            _configurationServiceFactory = configurationServiceFactory;
        }

        public ILoggerService CreateSerilogLoggerService(string settingsFilePath, string settingsFileName, string filePath, string fileName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(settingsFilePath);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(settingsFileName);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(filePath);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(fileName);

            var configuration = _configurationServiceFactory
                .CreateConfigurationService(settingsFilePath, settingsFileName)
                .GetConfigurationSection<IConfiguration>(_serilogConfigKey);

            var fullFilePath = Path.Combine(filePath, fileName);

            return new SerilogLoggerService(configuration, fullFilePath);
        }
    }
}
