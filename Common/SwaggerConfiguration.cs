
using Microsoft.Extensions.Configuration;

namespace Common
{
    public class SwaggerConfiguration : BaseConfiguration
    {
        public SwaggerConfiguration(IConfiguration configuration) : base("Swagger", configuration)
        {

        }
        public string SwaggerProjectVersion => GetSetting<string>("ProjectVersion");

        /// <summary>
        /// Gets the Project Name from the configuration
        /// AppSetting: Swagger:ProjectName
        /// </summary>
        public string SwaggerProjectName => GetSetting<string>("ProjectName");

        /// <summary>
        /// Gets the Version from the configuration
        /// AppSettings: Swagger:Version
        /// </summary>
        public string SwaggerVersion => GetSetting<string>("Version");

        /// <summary>
        /// Gets the Description from the configuration
        /// AppSettings: Swagger:Description
        /// </summary>
        public string SwaggerDescription => GetSetting<string>("Description");
    }
}
