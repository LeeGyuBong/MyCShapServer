namespace WebApplication1.System
{
    public class Config
    {
        #region Singletone

        private static volatile Config? __instance;
        private static readonly object __lock = new object();

        public static Config Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (__lock)
                    {
                        if (__instance == null)
                        {
                            __instance = new Config();
                        }
                    }
                }
                return __instance;
            }
        }

        #endregion

        public bool Load(IConfiguration config)
        {
            //IConfigurationSection section;

            //section = config.GetSection("Test");
            //int a = section.GetValue<int>("check");

            return true;
        }
    }
}
