// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    ///     SQL Server specific extension methods for <see cref="TableBuilder" />.
    /// </summary>
    public static class SqlServerTableBuilderExtensions
    {
        /// <summary>
        ///     TODO: add comments
        /// </summary>
        public static TableBuilder IsTemporal(
            this TableBuilder tableBuilder,
            Action<TemporalTableBuilder> buildAction)
        {
            tableBuilder.EntityTypeBuilder.Metadata.SetIsTemporal(true);
            buildAction(new TemporalTableBuilder(tableBuilder.EntityTypeBuilder));

            return tableBuilder;
        }

        /// <summary>
        ///     TODO: add comments
        /// </summary>
        public static TableBuilder IsTemporal(
            this TableBuilder tableBuilder)
        {
            tableBuilder.EntityTypeBuilder.Metadata.SetIsTemporal(true);

            return tableBuilder;
        }

        /// <summary>
        ///     TODO: add comments
        /// </summary>
        public static TableBuilder<TEntity> IsTemporal<TEntity>(
            this TableBuilder<TEntity> tableBuilder)
            where TEntity : class
        {
            tableBuilder.EntityTypeBuilder.Metadata.SetIsTemporal(true);

            return tableBuilder;
        }

        /// <summary>
        ///     TODO: add comments
        /// </summary>
        public static TableBuilder<TEntity> IsTemporal<TEntity>(
            this TableBuilder<TEntity> tableBuilder,
            Action<TemporalTableBuilder<TEntity>> buildAction)
            where TEntity: class
        {
            tableBuilder.EntityTypeBuilder.Metadata.SetIsTemporal(true);
            buildAction(new TemporalTableBuilder<TEntity>(tableBuilder.EntityTypeBuilder));

            return tableBuilder;
        }
    }
}
