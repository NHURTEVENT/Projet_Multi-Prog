using KitchenModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDAO
{
    class TestWrapper
    {
        public SqlConnection testConnection(string connectionString)
        {
            KitchenContext ct = new KitchenContext();
            ModelDAOInitializer model = new ModelDAOInitializer(ct);
            var co = new SqlConnection(connectionString);
            return co;
        }

        public string getConnectionString()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings cs in settings)
            {
                return cs.ConnectionString;
            }

            throw new Exception("no connection string found exception");
        }
    }
}
