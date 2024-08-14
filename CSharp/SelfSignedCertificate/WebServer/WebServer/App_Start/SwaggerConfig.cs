using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;
using WebServer;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebServer
{
    /// <summary>
    /// swaggerÇÃê›íË
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// ìoò^(é©ìÆê∂ê¨)
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        // Use "SingleApiVersion" to describe a single version API. Swagger 2.0 includes an "Info" object to
                        // hold additional metadata for an API. Version and title are required but you can also provide
                        // additional fields by chaining methods off SingleApiVersion.
                        //
                        c.SingleApiVersion("v1", "WebServer");

                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
        /// <summary>
        /// XMLÉtÉ@ÉCÉãÇÃì«Ç›éÊÇË
        /// </summary>
        /// <returns></returns>
        public static string GetXmlCommentsPath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(baseDirectory, "bin", xmlFileName);
        }
    }
}
