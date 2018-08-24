using System;

namespace System.Application.DataAccess.Common
{
    public interface IConnectionFactory
    {    
        IConnection CreateConneciton(string connectionString);
    }
}
