using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Swashbuckle.Swagger.Annotations;

namespace WebApI2017.Controllers
{
    /// <summary>
    /// ファイルアップロードのイベントハンドラ
    /// </summary>
    public class UploadController : ApiController
    {
        /// <summary>
        /// Postメソッド
        /// </summary>
        /// <returns>Httpステータスコード</returns>
        [SwaggerOperationFilter(typeof(UploadFileOperationFilter))]
        public async Task<IHttpActionResult> PostFile()
        {
            // multipart/form-data以外、サポート外のメディア種類(Http Status 415)を返す
            if(!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }
            // multipart/form-dataを保存する場所を指定する
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            //Responseボディー情報を保持する変数
            var sb = new StringBuilder();
            try
            {
                //非同期でデータを読み取る
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var value in provider.FormData.GetValues(key))
                    {
                        sb.Append($"{key}:{value}\n");
                    }
                }
                foreach (var file in provider.FileData)
                {
                    var fileInfo = new FileInfo(file.LocalFileName);
                    sb.Append($"Uploaded File:{fileInfo.Name} ({fileInfo.Length} bytes\n");
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok(sb.ToString());
        }
    }
}
