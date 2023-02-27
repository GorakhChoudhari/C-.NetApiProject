/*using KE.FrameworkAttributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace KE.Repository.Helpers
{
    public static class AttributeMapper
    {
        public static string GetColumnNameFromAttribute(MemberInfo member)
        {
            if (member == null) return null;

            var attribute = (ColumnAttribute)Attribute.GetCustomAttribute(member, typeof(ColumnAttribute), false);
            return (attribute?.Name ?? member.Name).ToLower();
        }

        public static bool IsDbTypeStringAttributeSet(MemberInfo member)
        {
            if (member == null) return false;
            var attribute = (DbTypeStringAttribute)Attribute.GetCustomAttribute(member, typeof(DbTypeStringAttribute), false);
            return attribute != null;
        }

        public static bool IsDbTypeIntAttributeSet(MemberInfo member)
        {
            if (member == null) return false;
            var attribute = (DbTypeIntAttribute)Attribute.GetCustomAttribute(member, typeof(DbTypeIntAttribute), false);
            return attribute != null;
        }
    }
}
*/