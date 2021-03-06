using System.Web.Http;
using WebActivatorEx;
using MultiPartServer;
using Swashbuckle.Application;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace MultiPartServer
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MultiPartServer");
                        //XMLファイルを読込む
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
        private static string GetXmlCommentsPath()
        {
#warning パスはXMLドキュメントファイルの設定に合わせて修正すること
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin", "MultiPartServer.xml");
        }
    }
}
