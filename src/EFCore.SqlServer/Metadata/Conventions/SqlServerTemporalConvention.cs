// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal;

namespace Microsoft.EntityFrameworkCore.Metadata.Conventions
{
    /// <summary>
    ///     TODO: add comments
    /// </summary>
    public class SqlServerTemporalConvention : IEntityTypeAnnotationChangedConvention
    {
        private const string PeriodStartDefaultName = "PeriodStart";
        private const string PeriodEndDefaultName = "PeriodEnd";

        /// <summary>
        ///     TODO: add comments
        /// </summary>
        public virtual void ProcessEntityTypeAnnotationChanged(
            IConventionEntityTypeBuilder entityTypeBuilder,
            string name,
            IConventionAnnotation? annotation,
            IConventionAnnotation? oldAnnotation,
            IConventionContext<IConventionAnnotation> context)
        {
            if (name == SqlServerAnnotationNames.IsTemporal)
            {
                if (annotation?.Value as bool? == true)
                {
                    if (entityTypeBuilder.Metadata.TemporalPeriodStartPropertyName() == null)
                    {
                        entityTypeBuilder.Metadata.SetTemporalPeriodStartPropertyName(PeriodStartDefaultName);
                    }

                    if (entityTypeBuilder.Metadata.TemporalPeriodEndPropertyName() == null)
                    {
                        entityTypeBuilder.Metadata.SetTemporalPeriodEndPropertyName(PeriodEndDefaultName);
                    }
                }
                else
                {
                    entityTypeBuilder.Metadata.RemoveAnnotation(SqlServerAnnotationNames.TemporalPeriodStartPropertyName);
                    entityTypeBuilder.Metadata.RemoveAnnotation(SqlServerAnnotationNames.TemporalPeriodEndPropertyName);
                }
            }

            if (name == SqlServerAnnotationNames.TemporalPeriodStartPropertyName
                || name == SqlServerAnnotationNames.TemporalPeriodEndPropertyName)
            {
                if (oldAnnotation?.Value is string oldPeriodPropertyName)
                {
                    var oldPeriodProperty = entityTypeBuilder.Metadata.GetProperty(oldPeriodPropertyName);
                    entityTypeBuilder.RemoveUnusedImplicitProperties(new[] { oldPeriodProperty });

                    if (oldPeriodProperty.GetTypeConfigurationSource() == ConfigurationSource.Explicit)
                    {
                        if (oldPeriodProperty.GetDefaultValueConfigurationSource() == ConfigurationSource.Convention
                            && ((name == SqlServerAnnotationNames.TemporalPeriodStartPropertyName
                                && oldPeriodProperty.GetDefaultValue() is DateTime start
                                && start == DateTime.MinValue)
                            || (name == SqlServerAnnotationNames.TemporalPeriodEndPropertyName
                                && oldPeriodProperty.GetDefaultValue() is DateTime end
                                && end == DateTime.MaxValue)))
                        {
                            oldPeriodProperty.SetDefaultValue(null);
                        }
                    }
                }

                if (annotation?.Value is string periodPropertyName)
                {
                    var periodPropertyBuilder = entityTypeBuilder.Property(
                        typeof(DateTime),
                        periodPropertyName);

                    if (periodPropertyBuilder != null)
                    {
                        // set column name explicitly so that we don't try to uniquefy it to some other column
                        // in case another property is defined that maps to the same column
                        periodPropertyBuilder.HasColumnName(periodPropertyName);

                        periodPropertyBuilder.HasDefaultValue(
                            name == SqlServerAnnotationNames.TemporalPeriodStartPropertyName
                                ? DateTime.MinValue
                                : DateTime.MaxValue);
                    }
                }
            }
        }
    }
}
