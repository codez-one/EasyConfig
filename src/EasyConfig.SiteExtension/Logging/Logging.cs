namespace EasyConfig.SiteExtension;

using Microsoft.Extensions.Logging;

// For more info have a look here:
// https://docs.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator

public static partial class Logging
{
    public static partial class Controllers
    {
        public static partial class Config
        {
            [LoggerMessage(
                EventId = 1,
                Level = LogLevel.Information,
                Message = "Get Environment Config called."
            )]
            internal static partial void GetConfigRequested(ILogger logger);
        }
    }
}