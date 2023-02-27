using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTS.FrameworkExtensions
{
    public static class ConfigurationExtension
    {
        public static T GetAzureKeyVaultValue<T>(this IConfiguration configuration,string keyToAppSettings)
        {
            return configuration.GetValue<T>(configuration.GetValue<string>(keyToAppSettings));
        }
        public static T GetAzureKeyVaultValue<T>(this IConfiguration configuration, string keyToAppSettings, T defaultValue)
        {
            return configuration.GetValue<T>(configuration.GetValue<string>(keyToAppSettings),defaultValue);
        }
    }
}
