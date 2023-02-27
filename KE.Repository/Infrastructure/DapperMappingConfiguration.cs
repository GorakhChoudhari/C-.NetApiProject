using Dapper;
using KE.Repository.Helpers;
using KE.Repository.Helpers.Helpers;
using System;
using System.Linq;

namespace KE.Repository.Infrastructure
{
    public static  class DapperMappingConfiguration
    {
        public static void ConfigureDapperMappings()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = false;
            SqlMapper.AddTypeHandler(new DateTimeHandler());
            var entityTypes = typeof(DapperMappingConfiguration).Assembly.GetTypes().Where(t=>t.Namespace == "Emids.ARCPortal.Repository.Entities");// add when you create view models
            var mapEntityMethod = typeof(DapperMappingConfiguration).GetMethod(nameof(DapperMappingConfiguration.MapEntity));

            foreach (var type in entityTypes)
            {
                var genericMethod = mapEntityMethod.MakeGenericMethod(type);
                genericMethod.Invoke(null, null);
            }
        }

        public static void MapEntity<T>()
        {
             var map = new CustomPropertyTypeMap(typeof(T), (type, columnName) => type.GetProperties().FirstOrDefault(prop => MatchColumnNames(AttributeMapper.GetColumnNameFromAttribute(prop), columnName)));
            SqlMapper.SetTypeMap(typeof(T), map);
        }

        private static bool MatchColumnNames(string columnNameFromPropertyOrAttribute,string columnName)
        {
            if (!DefaultTypeMap.MatchNamesWithUnderscores)
            {
                return string.Equals(columnNameFromPropertyOrAttribute.Replace("_", ""), columnName.Replace("_", "").ToLower(), StringComparison.OrdinalIgnoreCase);
            }
            return string.Equals(columnNameFromPropertyOrAttribute, columnName.ToLower(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
