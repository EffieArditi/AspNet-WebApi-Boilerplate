using System.Configuration;

namespace WebApi.Testing.Common
{
    public static class ConfigurationHelper
    {
        public static string GetCurrentEnvDbConnString()
        {
            string currentEnv = ConfigurationManager.AppSettings["Environment"].ToLower();

            string connString;
            switch (currentEnv)
            {
                case "debug":
                    connString = ConfigurationManager.AppSettings["MONGOHQ_URL-Debug"];
                    break;
                case "test":
                    connString = ConfigurationManager.AppSettings["MONGOHQ_URL-Dev"];
                    break;
                default:
                    connString = ConfigurationManager.AppSettings["MONGOHQ_URL-Debug"];
                    break;
            }

            return connString;
        }
    }
}
