using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KE.Repository.Helpers.Helpers
{
    public class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
    {
        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
            parameter.Value = value;
        }

        public override DateTime Parse(object value)
        {
            if(value is DateTime dateTime)
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);

            return DateTime.SpecifyKind(Convert.ToDateTime(value), DateTimeKind.Unspecified);
        }
    }
}
