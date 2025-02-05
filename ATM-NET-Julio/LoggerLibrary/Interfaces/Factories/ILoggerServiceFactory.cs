using LoggerLibrary.Interfaces.Services;

namespace LoggerLibrary.Interfaces.Factories
{
    public interface ILoggerServiceFactory
    {
        ILoggerService CreateSerilogLoggerService(string settingsFilePath, string settingsFileName, string filePath, string fileName);
    }
}