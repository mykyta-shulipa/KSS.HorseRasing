﻿namespace KSS.HorseRacing.Infrastucture.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class LinqExtensions
    {
        #region WhereIf
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        #endregion

        #region Sorting

        /// <summary>
        /// The order by expression.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <typeparam name="TEntity">
        /// The general entity.
        /// </typeparam>
        /// <returns>
        /// The System.Linq.IOrderedQueryable`1[T -&gt; TEntity].
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown when source is null.
        /// </exception>
        public static IOrderedQueryable<TEntity> OrderByExpression<TEntity>(this IQueryable<TEntity> source, string sortExpression) where TEntity : class
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source is null.");
            }

            if (string.IsNullOrWhiteSpace(sortExpression))
            {
                sortExpression = "Id";
            }

            var orderFields = sortExpression.Split(',');
            IOrderedQueryable<TEntity> result = null;
            for (var currentFieldIndex = 0; currentFieldIndex < orderFields.Length; currentFieldIndex++)
            {
                var expressionPart = orderFields[currentFieldIndex].Trim().Split(' ');
                var sortField = expressionPart[0];
                var sortDescending = (expressionPart.Length == 2) && (expressionPart[1].Equals("DESC", StringComparison.OrdinalIgnoreCase));
                if (sortDescending)
                {
                    result = currentFieldIndex == 0 ? source.orderByDescending(sortField) : result.thenByDescending(sortField);
                }
                else
                {
                    result = currentFieldIndex == 0 ? source.orderBy(sortField) : result.thenBy(sortField);
                }
            }
            return result;
        }

        private static IOrderedQueryable<TEntity> orderBy<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            var resultExp = generateMethodCall(source, "OrderBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        private static IOrderedQueryable<TEntity> orderByDescending<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            var resultExp = generateMethodCall(source, "OrderByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        private static IOrderedQueryable<TEntity> thenBy<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            var resultExp = generateMethodCall(source, "ThenBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        private static IOrderedQueryable<TEntity> thenByDescending<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            var resultExp = generateMethodCall(source, "ThenByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        private static MethodCallExpression generateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, String fieldName) where TEntity : class
        {
            var type = typeof(TEntity);
            Type selectorResultType;
            var selector = generateSelector<TEntity>(fieldName, out selectorResultType);
            var resultExp = Expression.Call(typeof(Queryable), methodName, new[] { type, selectorResultType },
                            source.Expression, Expression.Quote(selector));
            return resultExp;
        }
        private static LambdaExpression generateSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "Entity");
            //  create the selector part, but support child properties
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields.
                var childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (var i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;
            // Create the order by expression.
            return Expression.Lambda(propertyAccess, parameter);
        }
        #endregion

        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }
    }
}
