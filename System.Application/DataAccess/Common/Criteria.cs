using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Application.DataAccess.Common
{
    public class Criteria<T> : ICriteria<T>
    {
        private Dictionary<string, List<Expression>> expressionDictionary;
        public Dictionary<string, List<Expression>> ExpressionDictionary
        {
            get { return expressionDictionary; }
        }

        public Criteria()
        {
            expressionDictionary = new Dictionary<string, List<Expression>>();
        }

        #region interface Method
        public ICriteria<T> Where(Expression<Func<T, bool>> predicate)
        {
            return AddExpression(SQLSyntax.Where, predicate);
        }

        public ICriteria<T> OrderBy<R>(Expression<Func<T, R>> predicate)
        {
            return AddExpression(SQLSyntax.OrderBy, predicate);
        }

        public ICriteria<T> OrderByDescending<R>(Expression<Func<T, R>> predicate)
        {
            return AddExpression(SQLSyntax.OrderByDescending, predicate);
        }

        public ICriteria<T> ThenBy<R>(Expression<Func<T, R>> predicate)
        {
            return AddExpression(SQLSyntax.ThenBy, predicate);
        }

        public ICriteria<T> ThenByDescending<R>(Expression<Func<T, R>> predicate)
        {
            return AddExpression(SQLSyntax.ThenByDescending, predicate);
        }

        public ICriteria<T> GroupBy<R>(Expression<Func<T, R>> predicate)
        {
            return AddExpression(SQLSyntax.GroupBy, predicate);
        }
        #endregion

        #region private Method
        private ICriteria<T> AddExpression(SQLSyntax key, Expression predicate)
        {
            List<Expression> expressionList = null;
            if (!(expressionDictionary.TryGetValue(key.ToString(), out expressionList)))
            {
                expressionList = new List<Expression>() { predicate };
                this.expressionDictionary.Add(key.ToString(), expressionList);
            }
            else
            {
                expressionList = this.expressionDictionary[key.ToString()];
                expressionList.Add(predicate);
                this.expressionDictionary[key.ToString()] = expressionList;
            }
            return this;
        }
        #endregion
    }
}
