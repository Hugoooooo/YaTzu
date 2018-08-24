using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Application.DataAccess.Common;
using System.Data;
using System.Data.SqlClient;
using System.Application.Common;

namespace System.Application.DataAccess.Provider.SQLServer
{
    public class SQLConnectionFactory: IConnectionFactory
    {
        public static string DataSource;
        public static string InitialCatalog;
        public static string UserID;
        public static string UserIDWithDES;
        public static string Password;
        public static string PasswordWithDES;
        public static int ConnectTimeout;
        public static int MaxPoolSize;
        public static int MinPoolSize;

        public static string GenConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.IntegratedSecurity = false;
            connectionStringBuilder.DataSource = DataSource;
            connectionStringBuilder.InitialCatalog = InitialCatalog;
            if (string.IsNullOrEmpty(UserIDWithDES))
                connectionStringBuilder.UserID = UserID;
            else connectionStringBuilder.UserID = My.DecryptByDES(UserIDWithDES);
            if (string.IsNullOrEmpty(PasswordWithDES))
                connectionStringBuilder.Password = Password;
            else connectionStringBuilder.Password = My.DecryptByDES(PasswordWithDES);
            connectionStringBuilder.ConnectTimeout = ConnectTimeout > 0 ? ConnectTimeout : 30; //Sec(default 15)
            connectionStringBuilder.Pooling = true;
            connectionStringBuilder.MaxPoolSize = MaxPoolSize > 0 ? MaxPoolSize : 100;
            connectionStringBuilder.MinPoolSize = MinPoolSize > 0 ? MinPoolSize : 0;

            return connectionStringBuilder.ConnectionString;
        }
           
        public IConnection CreateConneciton(string connectionString)
        {
            return new SQLConnection(connectionString);
        }
    }
}
