using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace WebApI2017.Controllers
{
    /// <summary>
    /// Swagger　UI用ファイルアップロードフィルタ
    /// </summary>
    public class UploadFileOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.consumes.Add("multipart/form-data");
            operation.parameters = new[]
            {
                new Parameter()
                {
                    name = "File",
                    @in = "formData",
                    required = true,
                    type = "file",
                    description = "UploadFile"
                },
            };
        }
    }
}