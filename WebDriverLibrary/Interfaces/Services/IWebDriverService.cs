using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Interfaces.Services;

public interface IWebDriverService : IDisposable
{
    void ApplyConfigurations();
    void DisposeWebDriver();
    string GetCurrentTitle();
    string GetCurrentUrl();
    IWebDriver GetWebDriver();
    IWebDriverConfiguration GetWebDriverConfiguration();
    void NavigateTo(string url);
}