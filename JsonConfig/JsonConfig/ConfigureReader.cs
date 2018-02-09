

namespace JsonConfig
{
    using System.IO;

    using Microsoft.Extensions.Configuration;
    
    public static class ConfigureReader
    {
        public static IConfigurationRoot CreateConfig(string fileName)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(fileName);

            return builder.Build();
        }
    }
}
