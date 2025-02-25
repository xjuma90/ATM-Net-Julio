using ConfigurationLibrary.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Enums;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Configuration;

public class WebDriverConfiguration : IWebDriverConfiguration
{
    private const string _configurationSection = "WebDriverConfiguration";

    public BrowserType BrowserType { get; set; }

    public bool IsHeadless { get; set; }

    public bool IsIncognito { get; set; }

    public bool IsMaximized { get; set; }

    public PageLoadStrategy PageLoadStrategy { get; set; }

    public TimeSpan PageLoadTimeout { get; set; }

    public TimeSpan ImplicitTimeout { get; set; }

    public TimeSpan AsyncJavascriptTimeout { get; set; }

    public TimeSpan LongTimeout { get; set; }

    public TimeSpan MediumTimeout { get; set; }

    public TimeSpan ShortTimeout { get; set; }

    public TimeSpan PollingInterval { get; set; }


    public WebDriverConfiguration(IConfigurationService configurationService)
    {
        ArgumentNullException.ThrowIfNull(configurationService);

        var section = configurationService.GetConfigurationSection<IConfigurationSection>(_configurationSection);

        section.Bind(this);
    }
}
