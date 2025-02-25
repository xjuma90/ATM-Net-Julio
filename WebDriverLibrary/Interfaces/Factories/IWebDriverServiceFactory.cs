using WebDriverLibrary.Interfaces.Services;

namespace WebDriverLibrary.Interfaces.Factories;

public interface IWebDriverServiceFactory
{
    IWebDriverService CreateWebDriverService(string filePath, string fileName);
}