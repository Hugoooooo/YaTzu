using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Application.DataAccess.Common;

namespace System.Application.DataAccess.SQLStatement
{
    public class TSQLBuilder : SQLBuilder
    {
        private string _select = "";
        private string _top = "";
        private string _insert = "";
        private string _fields = "";
        private string _values = "";
        private string _update = "";
        private string _set = "";
        private string _delete = "";
        private string _from = "";
        private string _where = "";
        private string _orderby = "";
        private bool _hasOrderBy = false;

        public override string Query { get { return string.Format("{0}{1} {2} {3} {4}", _select, _top, _from, _where, _orderby); } }
        public override string Insert { get { return string.Format("{0} {1} {2}", _insert, _fields, _values); } }
        public override string Update { get { return string.Format("{0} {1} {2}", _update, _set, _where); } }
        public override string Delete { get { return string.Format("{0} {1}", _delete, _where); } }

        public override void BuildQuery(SQLSyntax syntax, params string[] statement)
        {
            switch(syntax)
            {
                case SQLSyntax.Select:
                    _select = "SELECT " + statement[0];
                    break;
                case SQLSyntax.Top:
                    _top = "SELECT TOP " + statement[0] + " " + statement[1];
                    break;
                case SQLSyntax.From:
                    _from = "FROM \"" + statement[0] + "\"";
                    break;
                case SQLSyntax.Where:
                    _where = "WHERE " + statement[0];
                    break;
                case SQLSyntax.OrderBy:
                    _hasOrderBy = true;
                    _orderby = "ORDER BY " + statement[0];
                    break;
                case SQLSyntax.OrderByDescending:
                    _hasOrderBy = true;
                    _orderby = "ORDER BY " + statement[0] + " DESC";
                    break;
                case SQLSyntax.ThenBy:
                    if (_hasOrderBy)
                        _orderby += ", " + statement[0];
                    else _orderby = "ORDER BY " + statement[0];
                    break;
                case SQLSyntax.ThenByDescending:
                    if (_hasOrderBy)
                        _orderby += ", " + statement[0] + " DESC";
                    else _orderby = "ORDER BY " + statement[0] + " DESC";
                    break;
            }
        }

        public override void BuildInsert(SQLSyntax syntax, string statement)
        {
            switch (syntax)
            {
                case SQLSyntax.Insert:
                    _insert = "INSERT INTO \"" + statement + "\"";
                    break;
                case SQLSyntax.Fields:
                    _fields = "(" + statement + ")";
                    break;
                case SQLSyntax.Values:
                    _values = "VALUES (" + statement + ")";
                    break;
            }
        }

        public override void BuildUpdate(SQLSyntax syntax, string statement)
        {
            switch (syntax)
            {
                case SQLSyntax.Update:
                    _update = "UPDATE \"" + statement + "\"";
                    break;
                case SQLSyntax.Set:
                    _set = "SET " + statement;
                    break;
                case SQLSyntax.Where:
                    _where = "WHERE " + statement;
                    break;
            }
        }

        public override void BuildDelete(SQLSyntax syntax, string statement)
        {
            switch (syntax)
            {
                case SQLSyntax.Delete:
                    _delete = "DELETE \"" + statement + "\"";
                    break;
                case SQLSyntax.Where:
                    _where = "WHERE " + statement;
                    break;
            }
        }
    }
}
