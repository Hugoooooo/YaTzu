using System.Application.DataAccess.Common;

namespace System.Application.DataAccess.SQLStatement
{
    public abstract class SQLBuilder
    {
        public abstract string Query { get; }
        public abstract string Insert { get; }
        public abstract string Update { get; }
        public abstract string Delete { get; }

        public abstract void BuildQuery(SQLSyntax syntax, params string[] statement);
        public abstract void BuildInsert(SQLSyntax syntax, string statement);
        public abstract void BuildUpdate(SQLSyntax syntax, string statement);
        public abstract void BuildDelete(SQLSyntax syntax, string statement);
    }
}
