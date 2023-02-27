using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTS.FrameworkExtensions
{
    public static class WebHostBuilderExtensions
    {
        public static void AddSharedSettings(this IConfigurationBuilder config,IHostEnvironment hostingEnvironment,string sharedFileName)
        {
            var fileStub = Path.GetFileNameWithoutExtension(sharedFileName);
            var fileExt = Path.GetExtension(sharedFileName);

            var fileNames = new List<string>
            {
                sharedFileName,
                $"{fileStub}.{hostingEnvironment.EnvironmentName}{fileExt}",
            };

            var sharedConfigs = new List<JsonConfigurationSource>();

            //first settings files are the ones in the shared folder
            // that get found when run via dotnet run

            var parentDir = Directory.GetParent(hostingEnvironment.ContentRootPath)?.Parent?.Parent;
            if(parentDir != null)
            {
                foreach (var fileName in fileNames)
                {
                    var filePath = Path.Combine(parentDir.FullName, fileName);

                    if (File.Exists(filePath))
                    {
                        sharedConfigs.Add(new JsonConfigurationSource()
                        {
                            Path = filePath,
                            Optional = true,
                            ReloadOnChange = true
                        });
                    }
                }
            }
            //second settings files are the linked shared settings file found when
            //Site is published
            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(hostingEnvironment.ContentRootPath, fileName);

                if (File.Exists(filePath))
                {
                    sharedConfigs.Add(new JsonConfigurationSource()
                    {
                        Path = filePath,
                        Optional = true,
                        ReloadOnChange = true
                    });
                }
            }

            sharedConfigs.ForEach(s =>s.ResolveFileProvider()); 

            if(config.Sources.Count> 0)
            {
                for(var idx = 0;idx < sharedConfigs.Count; idx++)
                {
                    config.Sources.Insert(idx, sharedConfigs[idx]);
                }
            }
            else sharedConfigs.ForEach(x => { config.Add(x); });
        }
    }
}
