using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CoronaStats.Api.StartupExtensions
{
    /// <summary>
    /// Class to configure swagger options to use api versioning
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {

        #region Members
        private const string API_TITLE = "Corona Stats API";
        private readonly IApiVersionDescriptionProvider _apiVersionProvider;
        #endregion

        #region ctor
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this._apiVersionProvider = provider ?? throw new ArgumentNullException(nameof(provider));
        }  
        #endregion

        #region Methods
        public void Configure(SwaggerGenOptions options)
        {
            // For each of the api version descriptions, generate a seperate document
            foreach (var description in this._apiVersionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo()
                    {
                        Title = $"{API_TITLE} {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                    } );
            }

            // Add the XML Comment generation for the swagger doc
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFileName);
            options.IncludeXmlComments(xmlPath);
        }

        #endregion
    }
}