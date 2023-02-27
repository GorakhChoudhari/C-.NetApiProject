using KE.Repository.Infrastructure.Interface;

namespace KE.Repository.Infrastructure
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        public string GetAllQuery(string tablename)
        {
            return $"select * from{tablename}";
        }
    }
}
