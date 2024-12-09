
namespace LoginServer
{
    public class Program
    {
        public static bool IsStart = false;

        public static void Main(string[] args)
        {
            BuildApplication(args)?.Run();
        }

        public static WebApplication? BuildApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration, builder.Environment);
            startup.ConfigureServices(builder.Services);

            WebApplication webApplication = builder.Build();

            startup.Configure(webApplication);

            if (IsStart == false)
            {
                return null;
            }

            return webApplication;
        }
    }
}
