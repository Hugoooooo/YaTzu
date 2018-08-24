using System.Application.Common;
using System.Application.DataAccess.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.DataAccess.Provider.Oracle
{
    public class OracleConnectionFactory : IConnectionFactory
    {
        public IConnection CreateConneciton(string connectionString)
        {
            return new OracleDBConnection(connectionString);
        }
    }
}
