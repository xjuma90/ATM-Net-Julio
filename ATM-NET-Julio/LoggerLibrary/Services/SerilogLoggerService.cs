using LoggerLibrary.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using System;

namespace LoggerLibrary.Services
{
    public class SerilogLoggerService : ILoggerService
    {
        private readonly Logger _logger;

        public SerilogLoggerService(IConfiguration configuration, string fullFilePath)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(fullFilePath);

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(fullFilePath)
                .Enrich.FromLogContext();

            _logger = loggerConfiguration.CreateLogger();
        }

        public void LogDebug(string message, params object?[]? args)
        {
            _logger.Debug(message, args);
        }

        public void LogInformation(string message, params object?[]? args)
        {
            _logger.Information(message, args);
        }

        public void LogWarning(string message, params object?[]? args)
        {
            _logger.Warning(message, args);
        }

        public void LogError(Exception? exception, string message, params object?[]? args)
        {
            _logger.Error(exception, message, args);
        }

        public void LogCritical(Exception? exception, string message, params object?[]? args)
        {
            _logger.Fatal(exception, message, args);
        }

        public void CloseAndflush()
        {
            _logger.Dispose();
        }
    }
}
