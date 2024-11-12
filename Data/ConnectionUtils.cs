using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class ConnectionUtils
    {
        private const string DB_CONFIG_NAME = "PartidoDBConfig";
        public static string GetDbConfig()
        {

            return ConfigurationManager.ConnectionStrings[DB_CONFIG_NAME].ConnectionString;
        }
    }
}
