using KE.Repository.Infrastructure;

namespace KE.Service.Mapping
{
    public static class DapperMapping
    {
        public static void AddDapperMappings()
        {
            DapperMappingConfiguration.ConfigureDapperMappings();
        }
    }
}
