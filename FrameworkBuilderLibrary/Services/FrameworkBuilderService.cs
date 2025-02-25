using ConfigurationLibrary.Interfaces.Services;
using ConfigurationLibrary.Services;
using LoggerLibrary.Factories;
using LoggerLibrary.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebDriverLibrary.Factories;
using WebDriverLibrary.Interfaces.Factories;

namespace FrameworkBuilderLibrary.Services
{
    public class FrameworkBuilderService
    {
        private  readonly ServiceCollection  _serviceCollection;

        public FrameworkBuilderService()
        {
            _serviceCollection = new ServiceCollection();
        }

        public FrameworkBuilderService AddConfigurationServiceFactory(ServiceLifetime serviceLifetime)
        {
            switch(serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    _serviceCollection.AddSingleton<IConfigurationService, ConfigurationService>();
                    break;
                case ServiceLifetime.Transient:
                    _serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
                    break;
                case ServiceLifetime.Scoped:
                    _serviceCollection.AddScoped<IConfigurationService, ConfigurationService>();
                    break;
            }

            return this;
        }

        public FrameworkBuilderService AddLoggerServiceFactory(ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    _serviceCollection.AddSingleton<ILoggerServiceFactory, LoggerServiceFactory>();
                    break;
                case ServiceLifetime.Transient:
                    _serviceCollection.AddTransient<ILoggerServiceFactory, LoggerServiceFactory>();
                    break;
                case ServiceLifetime.Scoped:
                    _serviceCollection.AddScoped<ILoggerServiceFactory, LoggerServiceFactory>();
                    break;
            }

            return this;
        }

        public FrameworkBuilderService AddWebDriverConfigurationFactory(ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    _serviceCollection.AddSingleton<IWebDriverConfigurationFactory, WebDriverConfigurationFactory>();
                    break;
                case ServiceLifetime.Transient:
                    _serviceCollection.AddTransient<IWebDriverConfigurationFactory, WebDriverConfigurationFactory>();
                    break;
                case ServiceLifetime.Scoped:
                    _serviceCollection.AddScoped<IWebDriverConfigurationFactory, WebDriverConfigurationFactory>();
                    break;
            }

            return this;
        }

        public FrameworkBuilderService AddWebDriverServiceFactory(ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    _serviceCollection.AddSingleton<IWebDriverServiceFactory, WebDriverServiceFactory>();
                    break;
                case ServiceLifetime.Transient:
                    _serviceCollection.AddTransient<IWebDriverServiceFactory, WebDriverServiceFactory>();
                    break;
                case ServiceLifetime.Scoped:
                    _serviceCollection.AddScoped<IWebDriverServiceFactory, WebDriverServiceFactory>();
                    break;
            }

            return this;
        }

        public IServiceProvider BuildFramework()
        {
            return _serviceCollection.BuildServiceProvider();
        }
    }

    

}
