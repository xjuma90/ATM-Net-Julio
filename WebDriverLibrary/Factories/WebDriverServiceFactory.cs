using System;
using WebDriverLibrary.Interfaces.Factories;
using WebDriverLibrary.Interfaces.Services;
using WebDriverLibrary.Services;

namespace WebDriverLibrary.Factories;

public class WebDriverServiceFactory : IWebDriverServiceFactory
{
    private readonly IWebDriverConfigurationFactory _webDriverConfigurationFactory;

    public WebDriverServiceFactory(IWebDriverConfigurationFactory webDriverConfigurationFactory)
    {
        _webDriverConfigurationFactory = webDriverConfigurationFactory;
    }


    public IWebDriverService CreateWebDriverService(string filePath, string fileName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);


        var webDriverConfiguration = _webDriverConfigurationFactory.CreateWebDriverConfiguration(filePath, fileName);

        return new SeleniumWebDriverService(webDriverConfiguration);
    }
}
