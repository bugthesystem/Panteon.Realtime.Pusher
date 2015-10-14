using System.Configuration;

namespace Panteon.Realtime.Pusher
{
    class Config
    {
        public static string PS_APP_ID = ConfigurationManager.AppSettings.Get("PS_APP_ID");
        public static string PS_APP_KEY = ConfigurationManager.AppSettings.Get("PS_APP_KEY");
        public static string PS_APP_SECRET = ConfigurationManager.AppSettings.Get("PS_APP_SECRET");
    }
}