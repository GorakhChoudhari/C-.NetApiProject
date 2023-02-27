

Errror: System.AggregateException: 'Some services are not able to be constructed 
Solution:var Configuration = new ConfigurationBuilder()    .SetBasePath(Directory.GetCurrentDirectory())    .AddJsonFile("ShareSetting.json", optional: false, reloadOnChange: true)   .Build(); builder.Services.AddInfrastructure(Configuration);
