using System;
using System.Data;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// IConnection : 資料庫連接介面。
    /// </summary>
    public interface IConnection
    {
        DatabaseType getDatabaseType();
        int executeNonQuery(string ASQLCommand);
        IDataReader executeReader(string ASQLCommand);
        object executeScalar(string ASQLCommand);
        DataSet fillDataSet(string ASQLCommand);
        DataSet fillDataSet(string ASQLCommand,int startRecord, int maxRecord);
        DataTable fillDataTable(string ASQLCommand);
        void startTransaction();
        void commitTransaction();
        void rollbackTransaction();

        string getConnectionString();

        bool keepAlive { get; }
        void openConnection();
        void closeConnection();

        //Audit
        Audit audit { get; set; }
    }
}
