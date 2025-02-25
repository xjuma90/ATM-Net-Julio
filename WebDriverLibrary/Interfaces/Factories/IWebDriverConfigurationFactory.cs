using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Interfaces.Factories;

public interface IWebDriverConfigurationFactory
{
    IWebDriverConfiguration CreateWebDriverConfiguration(string filePath, string fileName);
}