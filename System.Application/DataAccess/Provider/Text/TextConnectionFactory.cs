using System.IO;
using System.Application.DataAccess.Common;

namespace System.Application.DataAccess.Provider.Text
{
    public class TextConnectionFactory: IConnectionFactory
    {
        public static string GenConnectionString(string textFileName)
        {
            FileInfo fileInfo = new FileInfo(textFileName);
            return @"Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=" + fileInfo.DirectoryName + ";extensions=asc,csv,tab,txt";
        }
        public IConnection CreateConneciton(string connectionString)
        {
            return new TextConnection(connectionString);
        }
    }
}
