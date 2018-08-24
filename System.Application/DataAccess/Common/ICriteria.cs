using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Application.DataAccess.Common
{
    public enum SQLSyntax
    {
        Select,
        From,
        Where,
        OrderBy,
        OrderByDescending,
        ThenBy,
        ThenByDescending,
        Insert,
        Fields,
        Values,
        Update,
        Set,
        Delete,
        GroupBy,
        Distinct,
        Min,
        Max,
        Sum,
        Count,
        Top
    }

    public interface ICriteria<T>
    {
        Dictionary<string, List<Expression>> ExpressionDictionary { get; }

        ICriteria<T> Where(Expression<Func<T, bool>> predicate);

        ICriteria<T> OrderBy<R>(Expression<Func<T, R>> predicate);
        ICriteria<T> OrderByDescending<R>(Expression<Func<T, R>> predicate);

        ICriteria<T> ThenBy<R>(Expression<Func<T, R>> predicate);
        ICriteria<T> ThenByDescending<R>(Expression<Func<T, R>> predicate);

        ICriteria<T> GroupBy<R>(Expression<Func<T, R>> predicate);
    }
}
