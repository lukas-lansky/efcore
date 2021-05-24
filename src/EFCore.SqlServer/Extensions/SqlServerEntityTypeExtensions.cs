// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    ///     Entity type extension methods for SQL Server-specific metadata.
    /// </summary>
    public static class SqlServerEntityTypeExtensions
    {
        private const string DefaultHistoryTableNameSuffix = "History";

        /// <summary>
        ///     Returns a value indicating whether the entity type is mapped to a memory-optimized table.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> <see langword="true" /> if the entity type is mapped to a memory-optimized table. </returns>
        public static bool IsMemoryOptimized(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.MemoryOptimized] as bool? ?? false;

        /// <summary>
        ///     Sets a value indicating whether the entity type is mapped to a memory-optimized table.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <param name="memoryOptimized"> The value to set. </param>
        public static void SetIsMemoryOptimized(this IMutableEntityType entityType, bool memoryOptimized)
            => entityType.SetOrRemoveAnnotation(SqlServerAnnotationNames.MemoryOptimized, memoryOptimized);

        /// <summary>
        ///     Sets a value indicating whether the entity type is mapped to a memory-optimized table.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <param name="memoryOptimized"> The value to set. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> The configured value. </returns>
        public static bool? SetIsMemoryOptimized(
            this IConventionEntityType entityType,
            bool? memoryOptimized,
            bool fromDataAnnotation = false)
        {
            entityType.SetOrRemoveAnnotation(SqlServerAnnotationNames.MemoryOptimized, memoryOptimized, fromDataAnnotation);

            return memoryOptimized;
        }

        /// <summary>
        ///     Gets the configuration source for the memory-optimized setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the memory-optimized setting. </returns>
        public static ConfigurationSource? GetIsMemoryOptimizedConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.MemoryOptimized)?.GetConfigurationSource();

        /// <summary>
        ///     Returns a value indicating whether the entity type is mapped to a temporal table.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> <see langword="true" /> if the entity type is mapped to a temporal table. </returns>
        public static bool IsTemporal(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.IsTemporal] as bool? ?? false;

        /// <summary>
        ///     Sets a value indicating that the entity type is mapped to a temporal table and relevant mapping configuration.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <param name="temporal"> The value to set. </param>
        public static void SetIsTemporal(this IMutableEntityType entityType, bool temporal)
            => entityType.SetOrRemoveAnnotation(SqlServerAnnotationNames.IsTemporal, temporal);

        /// <summary>
        ///     Sets a value indicating that the entity type is mapped to a temporal table and relevant mapping configuration.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <param name="temporal"> The value to set. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> The configured value. </returns>
        public static bool? SetIsTemporal(
            this IConventionEntityType entityType,
            bool? temporal,
            bool fromDataAnnotation = false)
        {
            entityType.SetOrRemoveAnnotation(SqlServerAnnotationNames.IsTemporal, temporal, fromDataAnnotation);

            return temporal;
        }

        /// <summary>
        ///     Gets the configuration source for the temporal table setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the temporal table setting. </returns>
        public static ConfigurationSource? GetIsTemporalConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.IsTemporal)?.GetConfigurationSource();

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? TemporalPeriodStartPropertyName(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.TemporalPeriodStartPropertyName] as string;

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static void SetTemporalPeriodStartPropertyName(this IMutableEntityType entityType, string? perdionStartPropertyName)
            => entityType.SetAnnotation(SqlServerAnnotationNames.TemporalPeriodStartPropertyName, perdionStartPropertyName);

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? SetTemporalPeriodStartPropertyName(
            this IConventionEntityType entityType,
            string? perdionStartPropertyName,
            bool fromDataAnnotation = false)
        {
            entityType.SetAnnotation(
                SqlServerAnnotationNames.TemporalPeriodStartPropertyName,
                perdionStartPropertyName,
                fromDataAnnotation);

            return perdionStartPropertyName;
        }

        /// <summary>
        ///     Gets the configuration source for the temporal table period start property name setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the temporal table period start property name setting. </returns>
        public static ConfigurationSource? GetTemporalPeriodStartPropertyNameConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.TemporalPeriodStartPropertyName)?.GetConfigurationSource();

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? TemporalPeriodEndPropertyName(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.TemporalPeriodEndPropertyName] as string;

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static void SetTemporalPeriodEndPropertyName(this IMutableEntityType entityType, string? perdionEndPropertyName)
            => entityType.SetAnnotation(SqlServerAnnotationNames.TemporalPeriodEndPropertyName, perdionEndPropertyName);

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? SetTemporalPeriodEndPropertyName(
            this IConventionEntityType entityType,
            string? perdionEndPropertyName,
            bool fromDataAnnotation = false)
        {
            entityType.SetAnnotation(
                SqlServerAnnotationNames.TemporalPeriodEndPropertyName,
                perdionEndPropertyName,
                fromDataAnnotation);

            return perdionEndPropertyName;
        }

        /// <summary>
        ///     Gets the configuration source for the temporal table period end property name setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the temporal table period end property name setting. </returns>
        public static ConfigurationSource? GetTemporalPeriodEndPropertyNameConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.TemporalPeriodEndPropertyName)?.GetConfigurationSource();

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? TemporalHistoryTableName(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.TemporalHistoryTableName] is string historyTableName
                ? historyTableName
                : entityType[SqlServerAnnotationNames.IsTemporal] as bool? == true
                    ? entityType.ShortName() + DefaultHistoryTableNameSuffix
                    : null;

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static void SetTemporalHistoryTableName(this IMutableEntityType entityType, string? historyTableName)
            => entityType.SetAnnotation(SqlServerAnnotationNames.TemporalHistoryTableName, historyTableName);

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? SetTemporalHistoryTableName(
            this IConventionEntityType entityType,
            string? historyTableName,
            bool fromDataAnnotation = false)
        {
            entityType.SetAnnotation(
                SqlServerAnnotationNames.TemporalHistoryTableName,
                historyTableName,
                fromDataAnnotation);

            return historyTableName;
        }

        /// <summary>
        ///     Gets the configuration source for the temporal history table name setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the temporal history table name setting. </returns>
        public static ConfigurationSource? GetTemporalHistoryTableNameConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.TemporalHistoryTableName)?.GetConfigurationSource();

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? TemporalHistoryTableSchema(this IReadOnlyEntityType entityType)
            => entityType[SqlServerAnnotationNames.TemporalHistoryTableSchema] as string;

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static void SetTemporalHistoryTableSchema(this IMutableEntityType entityType, string? historyTableSchema)
            => entityType.SetAnnotation(SqlServerAnnotationNames.TemporalHistoryTableSchema, historyTableSchema);

        /// <summary>
        /// TODO: add comments
        /// </summary>
        public static string? SetTemporalHistoryTableSchema(
            this IConventionEntityType entityType,
            string? historyTableSchema,
            bool fromDataAnnotation = false)
        {
            entityType.SetAnnotation(
                SqlServerAnnotationNames.TemporalHistoryTableSchema,
                historyTableSchema,
                fromDataAnnotation);

            return historyTableSchema;
        }

        /// <summary>
        ///     Gets the configuration source for the temporal history table name setting.
        /// </summary>
        /// <param name="entityType"> The entity type. </param>
        /// <returns> The configuration source for the temporal history table name setting. </returns>
        public static ConfigurationSource? GetTemporalHistoryTableSchemaConfigurationSource(this IConventionEntityType entityType)
            => entityType.FindAnnotation(SqlServerAnnotationNames.TemporalHistoryTableSchema)?.GetConfigurationSource();
    }
}
