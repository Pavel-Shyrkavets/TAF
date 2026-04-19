using Microsoft.Extensions.Configuration;

namespace TAF.Core;

public class Configuration
{
    public static string BrowserType { get; private set; }

    public static string AppUrl { get; private set; }

    public static string TestDataPath { get; private set; }

    static Configuration() => Init();

    private static void Init()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        BrowserType = configuration["BrowserType"] ?? "Chrome";
        AppUrl = configuration["ApplicationUrl"] ?? string.Empty;
        TestDataPath = configuration["TestDataPath"] ?? string.Empty;
    }
}
