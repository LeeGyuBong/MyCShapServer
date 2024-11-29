using Microsoft.AspNetCore;
using System.Net;

namespace GameServer
{
    public class Program
    {
        public static bool IsStart = false;

        public static void Main(string[] args)
        {
            var isService = args.Contains("--service");
            var webHostcArgs = args.Where(arg => arg != "--service").ToArray();

            BuildWebHost(webHostcArgs)?.Run();
        }

        public static IWebHost? BuildWebHost(string[] args)
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;

            ConfigurationBuilder cb = new ConfigurationBuilder();
            IConfiguration config = cb.SetBasePath(currentDir)
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            IWebHost webHost = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseContentRoot(currentDir)
                .UseKestrel(option =>
                {
                    option.Listen(IPAddress.Any, 22361, listenOptions =>
                    {
                        //listenOptions.UseHttps()
                    });
                    option.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                    option.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
                })
                .UseStartup<Startup>()
                .Build();

            if (IsStart == false)
            {
                return null;
            }

            return webHost;
        }
    }
}
