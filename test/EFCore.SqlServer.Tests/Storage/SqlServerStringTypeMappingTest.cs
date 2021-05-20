// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal
{
    public class SqlServerStringTypeMappingTest
    {
        [ConditionalTheory]
        [InlineData("", "''")]
        [InlineData("'Sup", "'''Sup'")]
        [InlineData("I'm", "'I''m'")]
        [InlineData("lovin'", "'lovin'''")]
        [InlineData("it", "'it'")]
        [InlineData("'", "''''")]
        [InlineData("''", "''''''")]
        [InlineData("I'm lovin'", "'I''m lovin'''")]
        [InlineData("I'm lovin' it", "'I''m lovin'' it'")]
        [InlineData("\r", "CHAR(13)")]
        [InlineData("\n", "CHAR(10)")]
        [InlineData("\r\n", "CONCAT(CAST(CHAR(13) AS VARCHAR(MAX)), CHAR(10))")]
        [InlineData("\n'sup", "CONCAT(CAST(CHAR(10) AS VARCHAR(MAX)), '''sup')")]
        [InlineData("I'm\n", "CONCAT(CAST('I''m' AS VARCHAR(MAX)), CHAR(10))")]
        [InlineData("lovin'\n", "CONCAT(CAST('lovin''' AS VARCHAR(MAX)), CHAR(10))")]
        [InlineData("it\n", "CONCAT(CAST('it' AS VARCHAR(MAX)), CHAR(10))")]
        [InlineData("\nit", "CONCAT(CAST(CHAR(10) AS VARCHAR(MAX)), 'it')")]
        [InlineData("\nit\n", "CONCAT(CAST(CHAR(10) AS VARCHAR(MAX)), 'it', CHAR(10))")]
        [InlineData("'\n", "CONCAT(CAST('''' AS VARCHAR(MAX)), CHAR(10))")]
        public void GenerateProviderValueSqlLiteral_works(string value, string expected)
        {
            var mapping = new SqlServerStringTypeMapping("varchar(max)");
            Assert.Equal(expected, mapping.GenerateProviderValueSqlLiteral(value));
        }

        [ConditionalTheory]
        [InlineData("", "N''")]
        [InlineData("'Sup", "N'''Sup'")]
        [InlineData("I'm", "N'I''m'")]
        [InlineData("lovin'", "N'lovin'''")]
        [InlineData("it", "N'it'")]
        [InlineData("'", "N''''")]
        [InlineData("''", "N''''''")]
        [InlineData("I'm lovin'", "N'I''m lovin'''")]
        [InlineData("I'm lovin' it", "N'I''m lovin'' it'")]
        [InlineData("\r", "NCHAR(13)")]
        [InlineData("\n", "NCHAR(10)")]
        [InlineData("\r\n", "CONCAT(CAST(NCHAR(13) AS NVARCHAR(MAX)), NCHAR(10))")]
        [InlineData("\n'sup", "CONCAT(CAST(NCHAR(10) AS NVARCHAR(MAX)), N'''sup')")]
        [InlineData("I'm\n", "CONCAT(CAST(N'I''m' AS NVARCHAR(MAX)), NCHAR(10))")]
        [InlineData("lovin'\n", "CONCAT(CAST(N'lovin''' AS NVARCHAR(MAX)), NCHAR(10))")]
        [InlineData("it\n", "CONCAT(CAST(N'it' AS NVARCHAR(MAX)), NCHAR(10))")]
        [InlineData("\nit", "CONCAT(CAST(NCHAR(10) AS NVARCHAR(MAX)), N'it')")]
        [InlineData("\nit\n", "CONCAT(CAST(NCHAR(10) AS NVARCHAR(MAX)), N'it', NCHAR(10))")]
        [InlineData("'\n", "CONCAT(CAST(N'''' AS NVARCHAR(MAX)), NCHAR(10))")]
        public void GenerateProviderValueSqlLiteral_works_unicode(string value, string expected)
        {
            var mapping = new SqlServerStringTypeMapping("nvarchar(max)", unicode: true);
            Assert.Equal(expected, mapping.GenerateProviderValueSqlLiteral(value));
        }
    }
}
