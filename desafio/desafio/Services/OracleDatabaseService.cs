using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace desafio.Services
{
    public class OracleDatabaseService
    {
        private string _connectionString;
        public OracleDatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;
        }

        public OracleConnection GetConnection()
        {
            return new OracleConnection( _connectionString );
        }
    }
}