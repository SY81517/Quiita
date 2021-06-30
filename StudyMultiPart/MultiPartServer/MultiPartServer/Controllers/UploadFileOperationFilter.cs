using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace MultiPartServer.Controllers
{
    /// <summary>
    /// Swagger　UI用ファイルアップロードフィルタ
    /// </summary>
    /// <remarks>
    /// https://swagger.io/docs/specification/2-0/file-upload/
    /// https://swagger.io/specification/v2/?sbsearch=multipart%20form%20data
    /// https://swagger.io/docs/specification/describing-parameters/
    /// </remarks>
    public class UploadFileOperationFilter : IOperationFilter
    {
        public void Apply( Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription )
        {
//            operation.consumes.Add("application/json");
            operation.consumes.Add("multipart/form-data");
            operation.parameters = new[]
            {
                new Parameter()
                {
                    name = "id",
                    @in = "path",
                    required = true,
                    type = "string",
                    description = "Numeric ID of the user to get"
                },
                new Parameter()
                {
                    name = "File",
                    @in = "formData",
                    required = true,
                    type = "file",
                    description = "The file to upload."
                },
            };

        }
    }
}