using KE.Framework.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KTS.FrameworkExtensions
{
    public static class SettingsExtension
    {
        public const string DatabaseAdvancedSettings = "DatabaseAdvancedSettings";
      /*  public const string AzureKeyVaultKeys = "AzureKeyVaultKeys";*/

        public static void AddSettingsProvider(this IServiceCollection services, IConfiguration configuration)
        {
           /* var azureKeyVaultKeys = new AzureKeyValutKeys();*/
          /*  var azureKeysConfigurationSection = configuration.GetSection(AzureKeyVaultKeys);
            azureKeysConfigurationSection.Bind(azureKeyVaultKeys);*/

           /* services.Configure<AzureKeyValutKeys>(azureKeysConfigurationSection);*/
            services.Configure<DatabaseAdvancedSettingsOptions>(configuration.GetSection(DatabaseAdvancedSettings));
           /* services.Configure<AzureKeyValutValues>(opt =>
            {
                opt.DatabaseConnectionString = configuration.GetValue<string>(azureKeyVaultKeys.DatabaseConnectionString, null);
                opt.ApplicationClientId = configuration.GetValue<string>(azureKeyVaultKeys.ApplicationClientId, null);
                opt.ApplicationClientSecret = configuration.GetValue<string>(azureKeyVaultKeys.ApplicationClientSecret, null);

            });*/
        }
    }
}
