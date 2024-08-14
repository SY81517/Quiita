namespace ConsoleApplication1.Properties
{
    public class AppSetting
    {
        private static object Locker = new object();
        
        private static AppSetting _instance  = null;

        public static AppSetting Instance
        {
            get
            {
                lock (Locker)
                {
                    return _instance ?? new AppSetting();
                }
            }
        }

        private IConfiguration _configuration;
        private AppSetting()
        {
            _configuration = new ConfigurationWrapper();
        }

        public string GetHoge()
        {
            lock (Locker)
            {
                return _configuration.User();
            }
        }
    }
}