using Kros.KORM;
using Kros.KORM.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korm.Data
{
    public class KormDatabase
    {
        private string _connectionString = string.Empty;

        public KormDatabase()
        {
            InitConnectionString();
        }

        private void InitConnectionString()
        {
            var connBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @"VALJASEK\SQL2017",
                InitialCatalog = "Northwind",
                IntegratedSecurity = true
            };
            _connectionString = connBuilder.ConnectionString;
        }

        public IDbSet<T> GetAllData<T>()
        {
            IDbSet<T> ret = null;
            using (Database db = new Database(_connectionString, "System.Data.SqlCLient"))
            {
                ret = db.Query<T>().AsDbSet();
            }
            return ret;
        }

        public IDbSet<T> GetAllDataViaJoin<T>(string selectPart, string wherePart)
        {
            IDbSet<T> ret = null;
            using (Database db = new Database(_connectionString, "System.Data.SqlCLient"))
            {
                ret = db.Query<T>().Select(selectPart).From(wherePart).AsDbSet();
            }
            return ret;
        }
    }
}
