namespace Test.Utility
{
    internal class Singleton<T> where T : class, new()
    {
        private static volatile T? __instance = null;
        private static readonly object __lock = new();

        public static T? GetInstance()
        {
            if (__instance == null)
            {
                lock (__lock)
                {
                    __instance ??= new T();
                }
            }
            return __instance;
        }
    }
}
