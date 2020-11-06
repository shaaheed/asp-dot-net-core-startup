﻿using System;
using System.Linq;

namespace Msi.Utilities.Filter
{
    public static class PaginationUtilities
    {

        private static PaginationUtilitiesOptions _utilitiesOptions;

        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, IPagingOptions options)
        {
            _utilitiesOptions = _utilitiesOptions ?? PaginationUtilitiesOptions.DefaultOptions;
            options = options ?? _utilitiesOptions.PagingOptions;

            options.Offset = options.Offset ?? _utilitiesOptions.PagingOptions.Offset;
            options.Limit = options.Limit ?? _utilitiesOptions.PagingOptions.Limit;

            query = query.Skip(options.Offset.Value).Take(options.Limit.Value);

            return query;
        }

        public static void Configure(Action<PaginationUtilitiesOptions> options)
        {
            _utilitiesOptions = new PaginationUtilitiesOptions();
            options.Invoke(_utilitiesOptions);
        }

        public static string BuildSql(this IPagingOptions pagingOptions)
        {
            _utilitiesOptions = _utilitiesOptions ?? PaginationUtilitiesOptions.DefaultOptions;
            pagingOptions = pagingOptions ?? _utilitiesOptions.PagingOptions;
            if (pagingOptions != null)
            {
                var offset = pagingOptions.Offset.Value;
                var limit = pagingOptions.Limit.Value;
                return $"offset {offset} rows fetch next {limit} rows only";
            }
            return string.Empty;
        }


    }
}
