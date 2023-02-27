using System;
using System.Collections.Generic;
using System.Linq;

namespace KE.Repository.Helpers
{
    public static class QueryHelper
    {
        public static string GetCondition(string Field, string _operator, string value)
        {
            switch (_operator)
            {
                case "eq":
                    return Field + " = '" + value +"'";
                default:
                    return null;
            }
        } 
    }
}
