using System.Configuration;
namespace CSMP_V2
{
    public static class ConfigManager
    {
        public static class General
        {
            public static readonly string WebAppTitle;
            static General()
            {
                WebAppTitle = ConfigurationManager.AppSettings["WebAppTitle"];
            }
        }

        public static class Database
        {
            public static readonly string DatabaseConnection;
            static Database()
            {
                DatabaseConnection = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            }
        }
    }
}