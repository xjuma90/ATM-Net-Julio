using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverLibrary.Enums;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.Services;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverLibrary.Services;

public class SeleniumWebDriverService : IWebDriverService
{
    private readonly IWebDriverConfiguration _webDriverConfiguration;
    private readonly IWebDriver _webDriver;
    private bool _disposed = false;

    public SeleniumWebDriverService(IWebDriverConfiguration webDriverConfiguration)
    {
        _webDriverConfiguration = webDriverConfiguration;

        _webDriver = CreateWebDriver();

        ApplyConfigurations();
    }

    private IWebDriver CreateWebDriver()
    {
        return _webDriverConfiguration.BrowserType switch
        {
            BrowserType.Chrome => CreateChromeDriver(),
            BrowserType.Edge => CreateEdgeDriver(),
            BrowserType.Firefox => CreateFirefoxDriver(),
            _ => throw new NotSupportedException($"Browser type '{_webDriverConfiguration.BrowserType}' is not supported")
        };
    }

    private IWebDriver CreateChromeDriver()
    {
        _ = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = GetChromeOptions();

        var webDriver = new ChromeDriver(options);

        return webDriver;
    }

    private ChromeOptions GetChromeOptions()
    {
        var options = new ChromeOptions();

        if (_webDriverConfiguration.IsIncognito)
        {
            options.AddArgument("--incognito");
        }

        ApplyGeneralOptions(options);

        return options;
    }

    private void ApplyGeneralOptions(dynamic options)
    {
        if (_webDriverConfiguration.IsHeadless)
        {
            options.AddArgument("--headless");
        }
    }

    private IWebDriver CreateEdgeDriver()
    {
        _ = new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = GetEdgeOptions();

        var webDriver = new EdgeDriver(options);

        return webDriver;
    }

    private EdgeOptions GetEdgeOptions()
    {
        var options = new EdgeOptions();

        if (_webDriverConfiguration.IsIncognito)
        {
            options.AddArgument("--inprivate");
        }

        ApplyGeneralOptions(options);

        return options;
    }

    private IWebDriver CreateFirefoxDriver()
    {
        _ = new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = GetFirefoxOptions();

        var webDriver = new FirefoxDriver(options);

        return webDriver;
    }

    private FirefoxOptions GetFirefoxOptions()
    {
        var options = new FirefoxOptions();

        if (_webDriverConfiguration.IsIncognito)
        {
            options.AddArgument("--private");
        }

        ApplyGeneralOptions(options);

        return options;
    }

    public void ApplyConfigurations()
    {
        _webDriver.Manage().Timeouts().PageLoad = _webDriverConfiguration.PageLoadTimeout;
        _webDriver.Manage().Timeouts().ImplicitWait = _webDriverConfiguration.ImplicitTimeout;
        _webDriver.Manage().Timeouts().AsynchronousJavaScript = _webDriverConfiguration.AsyncJavascriptTimeout;

        _webDriver.Manage().Cookies.DeleteAllCookies();

        if (_webDriverConfiguration.IsMaximized)
        {
            _webDriver.Manage().Window.Maximize();
        }
    }

    public IWebDriver GetWebDriver()
    {
        return _webDriver;
    }

    public IWebDriverConfiguration GetWebDriverConfiguration()
    {
        return _webDriverConfiguration;
    }

    public void DisposeWebDriver()
    {
        if (_webDriver is not null)
        {
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }

    public void NavigateTo(string url)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);

        _webDriver.Navigate().GoToUrl(url);
    }

    public string GetCurrentUrl()
    {
        return _webDriver.Url;
    }

    public string GetCurrentTitle()
    {
        return _webDriver.Title;
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed && disposing)
        {
            DisposeWebDriver();

            _disposed= true;
        }
    }

    ~SeleniumWebDriverService()
    {
        Dispose(false);
    }
}
