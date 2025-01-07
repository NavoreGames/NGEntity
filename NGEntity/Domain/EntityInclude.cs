using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NGEntity.Models;
using NGEntity.Interfaces;

namespace NGEntity.Domain;

public class EntityInclude<TSource> : CommandData
{
    internal EntityInclude(Guid Identifier) : base(Identifier) { }

    public IEntityInclude<TSource, TProperty> Include<TProperty>(Expression<Func<TSource, TProperty>> field) { return default; }

    //internal static readonly MethodInfo IncludeMethodInfo
    //= typeof(EntityFrameworkQueryableExtensions)
    //    .GetTypeInfo().GetDeclaredMethods(nameof(Include))
    //    .Single(
    //        mi =>
    //            mi.GetGenericArguments().Length == 2
    //            && mi.GetParameters().Any(
    //                pi => pi.Name == "navigationPropertyPath" && pi.ParameterType != typeof(string)));

    //internal static readonly MethodInfo NotQuiteIncludeMethodInfo
    //    = typeof(EntityFrameworkQueryableExtensions)
    //        .GetTypeInfo().GetDeclaredMethods(nameof(NotQuiteInclude))
    //        .Single(
    //            mi =>
    //                mi.GetGenericArguments().Length == 2
    //                && mi.GetParameters().Any(
    //                    pi => pi.Name == "navigationPropertyPath" && pi.ParameterType != typeof(string)));


    //public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(
    //    this IQueryable<TEntity> source,
    //    Expression<Func<TEntity, TProperty>> navigationPropertyPath)
    //    where TEntity : class
    //{
    //    Check.NotNull(navigationPropertyPath, nameof(navigationPropertyPath));

    //    return new IncludableQueryable<TEntity, TProperty>(
    //        source.Provider is EntityQueryProvider
    //            ? source.Provider.CreateQuery<TEntity>(
    //                Expression.Call(
    //                    instance: null,
    //                    method: IncludeMethodInfo.MakeGenericMethod(typeof(TEntity), typeof(TProperty)),
    //                    arguments: new[] { source.Expression, Expression.Quote(navigationPropertyPath) }))
    //            : source);
    //}

    //// A version of Include that doesn't set the navigation as loaded
    //internal static IIncludableQueryable<TEntity, TProperty> NotQuiteInclude<TEntity, TProperty>(
    //    this IQueryable<TEntity> source,
    //    Expression<Func<TEntity, TProperty>> navigationPropertyPath)
    //    where TEntity : class
    //    => new IncludableQueryable<TEntity, TProperty>(
    //        source.Provider is EntityQueryProvider
    //            ? source.Provider.CreateQuery<TEntity>(
    //                Expression.Call(
    //                    instance: null,
    //                    method: NotQuiteIncludeMethodInfo.MakeGenericMethod(typeof(TEntity), typeof(TProperty)),
    //                    arguments: new[] { source.Expression, Expression.Quote(navigationPropertyPath) }))
    //            : source);

    //internal static readonly MethodInfo ThenIncludeAfterEnumerableMethodInfo
    //    = typeof(EntityFrameworkQueryableExtensions)
    //        .GetTypeInfo().GetDeclaredMethods(nameof(ThenInclude))
    //        .Where(mi => mi.GetGenericArguments().Length == 3)
    //        .Single(
    //            mi =>
    //            {
    //                var typeInfo = mi.GetParameters()[0].ParameterType.GenericTypeArguments[1];
    //                return typeInfo.IsGenericType
    //                    && typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);
    //            });

    //internal static readonly MethodInfo ThenIncludeAfterReferenceMethodInfo
    //    = typeof(EntityFrameworkQueryableExtensions)
    //        .GetTypeInfo().GetDeclaredMethods(nameof(ThenInclude))
    //        .Single(
    //            mi => mi.GetGenericArguments().Length == 3
    //                && mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsGenericParameter);


    //public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
    //    this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
    //    Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
    //    where TEntity : class
    //    => new IncludableQueryable<TEntity, TProperty>(
    //        source.Provider is EntityQueryProvider
    //            ? source.Provider.CreateQuery<TEntity>(
    //                Expression.Call(
    //                    instance: null,
    //                    method: ThenIncludeAfterEnumerableMethodInfo.MakeGenericMethod(
    //                        typeof(TEntity), typeof(TPreviousProperty), typeof(TProperty)),
    //                    arguments: new[] { source.Expression, Expression.Quote(navigationPropertyPath) }))
    //            : source);


    //public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
    //    this IIncludableQueryable<TEntity, TPreviousProperty> source,
    //    Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
    //    where TEntity : class
    //    => new IncludableQueryable<TEntity, TProperty>(
    //        source.Provider is EntityQueryProvider
    //            ? source.Provider.CreateQuery<TEntity>(
    //                Expression.Call(
    //                    instance: null,
    //                    method: ThenIncludeAfterReferenceMethodInfo.MakeGenericMethod(
    //                        typeof(TEntity), typeof(TPreviousProperty), typeof(TProperty)),
    //                    arguments: new[] { source.Expression, Expression.Quote(navigationPropertyPath) }))
    //            : source);

    //private sealed class IncludableQueryable<TEntity, TProperty> : IIncludableQueryable<TEntity, TProperty>, IAsyncEnumerable<TEntity>
    //{
    //    private readonly IQueryable<TEntity> _queryable;

    //    public IncludableQueryable(IQueryable<TEntity> queryable)
    //    {
    //        _queryable = queryable;
    //    }

    //    public Expression Expression
    //        => _queryable.Expression;

    //    public Type ElementType
    //        => _queryable.ElementType;

    //    public IQueryProvider Provider
    //        => _queryable.Provider;

    //    public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    //        => ((IAsyncEnumerable<TEntity>)_queryable).GetAsyncEnumerator(cancellationToken);

    //    public IEnumerator<TEntity> GetEnumerator()
    //        => _queryable.GetEnumerator();

    //    IEnumerator IEnumerable.GetEnumerator()
    //        => GetEnumerator();
    //}

    //internal static readonly MethodInfo StringIncludeMethodInfo
    //    = typeof(EntityFrameworkQueryableExtensions)
    //        .GetTypeInfo().GetDeclaredMethods(nameof(Include))
    //        .Single(
    //            mi => mi.GetParameters().Any(
    //                pi => pi.Name == "navigationPropertyPath" && pi.ParameterType == typeof(string)));

    ///// <summary>
    /////     Specifies related entities to include in the query results. The navigation property to be included is
    /////     specified starting with the type of entity being queried (<typeparamref name="TEntity" />). Further
    /////     navigation properties to be included can be appended, separated by the '.' character.
    ///// </summary>
    ///// <remarks>
    /////     See <see href="https://aka.ms/efcore-docs-load-related-data">Loading related entities</see> for more information
    /////     and examples.
    ///// </remarks>
    ///// <typeparam name="TEntity">The type of entity being queried.</typeparam>
    ///// <param name="source">The source query.</param>
    ///// <param name="navigationPropertyPath">A string of '.' separated navigation property names to be included.</param>
    ///// <returns>A new query with the related data included.</returns>
    ///// <exception cref="ArgumentNullException">
    /////     <paramref name="source" /> or <paramref name="navigationPropertyPath" /> is <see langword="null" />.
    ///// </exception>
    ///// <exception cref="ArgumentException"><paramref name="navigationPropertyPath" /> is empty or whitespace.</exception>
    //public static IQueryable<TEntity> Include<TEntity>(
    //    this IQueryable<TEntity> source,
    //    [NotParameterized] string navigationPropertyPath)
    //    where TEntity : class
    //{
    //    Check.NotEmpty(navigationPropertyPath, nameof(navigationPropertyPath));

    //    return
    //        source.Provider is EntityQueryProvider
    //            ? source.Provider.CreateQuery<TEntity>(
    //                Expression.Call(
    //                    instance: null,
    //                    method: StringIncludeMethodInfo.MakeGenericMethod(typeof(TEntity)),
    //                    arg0: source.Expression,
    //                    arg1: Expression.Constant(navigationPropertyPath)))
    //            : source;
    //}
}
