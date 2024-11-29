namespace GameServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public IWebHostEnvironment WebHostingEnvironment { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostingEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            //services.AddMvcCore().json
            services.AddMvc();

            Program.IsStart = true;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
