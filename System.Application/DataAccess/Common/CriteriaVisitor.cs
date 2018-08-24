using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Application.DataAccess.Common
{
    public class CriteriaVisitor : ExpressionVisitor
    {
        private StringBuilder sb;
        public enum SQLType { SQLServer, Oracle }
        private SQLType sqlType = SQLType.SQLServer;
        public CriteriaVisitor(SQLType type)
        {
            this.sqlType = type;
        }

        internal string TranslateToSQL(Expression expression)
        {
            sb = new StringBuilder();
            Visit(Evaluator.PartialEval(expression));
            return sb.ToString();
        }

        //欄位選取 : ExpressionType.Convert, ExpressionType.MemberAccess, ExpressionType.Call        
        //條件運算 : UnaryExpression, MemberExpression, BinaryExpression
        //資料設定 : ConstantExpression, MemberExpression, NewExpression, MethodCallExpression, BinaryExpression
                

        //二元運算子
        protected override Expression VisitBinary(BinaryExpression b)
        {
            sb.Append("(");
            Visit(b.Left);
            switch (b.NodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    sb.Append(" AND ");
                    break;
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    sb.Append(" OR ");
                    break;
                case ExpressionType.Equal:
                    sb.Append(" = ");
                    break;
                case ExpressionType.NotEqual:
                    sb.Append(" <> ");
                    break;
                case ExpressionType.LessThan:
                    sb.Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    sb.Append(" <= ");
                    break;
                case ExpressionType.GreaterThan:
                    sb.Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    sb.Append(" >= ");
                    break;
                default:
                    throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
            }
            Visit(b.Right);
            sb.Append(")");
            return b;
        }

        //常數值
        protected override Expression VisitConstant(ConstantExpression c)
        {
            IQueryable q = c.Value as IQueryable;
            if (q != null)
            {
                // assume constant nodes w/ IQueryables are table references
                sb.Append("SELECT * FROM ");
                sb.Append(q.ElementType.Name);
            }
            else if (c.Value == null)
            {
                sb.Append("NULL");
            }
            else
            {
                switch (Type.GetTypeCode(c.Value.GetType()))
                {
                    case TypeCode.Boolean:
                        sb.Append(((bool)c.Value) ? 1 : 0);
                        break;
                    case TypeCode.String:
                        sb.Append("N'");
                        sb.Append(c.Value);
                        sb.Append("'");
                        break;
                    case TypeCode.Object:
                        throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
                    default:
                        sb.Append(c.Value);
                        break;
                }
            }
            return c;
        }

        //
        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter) {
                sb.Append(m.Member.Name);
                return m;
            }
            throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));    
        }

        //方法
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.DeclaringType == typeof(string) || m.Method.DeclaringType == typeof(StringExtension))
            {
                switch (m.Method.Name)
                {
                    case "StartsWith":
                        sb.Append("(");
                        Visit(m.Object);
                        if (sqlType == SQLType.Oracle) sb.Append(" LIKE || ");
                        else if (sqlType == SQLType.SQLServer) sb.Append(" LIKE + ");
                            
                        Visit(m.Arguments[0]);
                        if (sqlType == SQLType.Oracle) sb.Append(" || '%')");
                        else if (sqlType == SQLType.SQLServer) sb.Append(" + '%')");

                        return m;
                    case "Contains":
                        sb.Append("(");
                        Visit(m.Object);
                        if (sqlType == SQLType.Oracle) sb.Append(" LIKE '%' || ");
                        else if (sqlType == SQLType.SQLServer) sb.Append(" LIKE '%' + ");
                        Visit(m.Arguments[0]);

                        if (sqlType == SQLType.Oracle) sb.Append(" || '%')");
                        else if (sqlType == SQLType.SQLServer) sb.Append(" + '%')");
                        return m;
                    case "EndsWith":
                        sb.Append("(");
                        Visit(m.Object);
                        if (sqlType == SQLType.Oracle) sb.Append(" LIKE '%' || ");
                        else if (sqlType == SQLType.SQLServer) sb.Append(" LIKE '%' + ");

                        Visit(m.Arguments[0]);
                        sb.Append(")");
                        return m;
                    case "In":
                        sb.Append("(");
                        Visit(m.Object);
                        sb.Append(" IN ");
                        Visit(m.Arguments[0]);
                        sb.Append(")");
                        return m;
                    case "Equal":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" = ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                    case "NotEqual":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" <> ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                    case "LessThan":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" < ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                    case "LessThanOrEqual":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" <= ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                    case "GreaterThan":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" > ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                    case "GreaterThanOrEqual":
                        sb.Append("(");
                        Visit(m.Arguments[0]);
                        sb.Append(" >= ");
                        Visit(m.Arguments[1]);
                        sb.Append(")");
                        return m;
                }
            }
            throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));            
        }

        //一元運算子
        protected override Expression VisitUnary(UnaryExpression u)
        {
            switch (u.NodeType)
            {
                case ExpressionType.Not:
                    sb.Append(" NOT ");
                    Visit(u.Operand);
                    break;
                default:
                    throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
            }
            return u;
        }
    }
}