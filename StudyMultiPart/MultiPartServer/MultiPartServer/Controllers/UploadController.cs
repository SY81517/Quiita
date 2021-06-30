using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Swashbuckle.Swagger.Annotations;

namespace MultiPartServer.Controllers
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
        public async Task<IHttpActionResult> PostFile(string id)
        {
            // multipart/form-data以外、サポート外のメディア種類(Http Status 415)を返す
            if(!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }
            // multipart/form-dataを保存する場所を指定する
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                //データを読み取る
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach(var file in provider.FileData)
                {
                    //ファイルに格納
                    var fileInfo = new FileInfo(file.LocalFileName);
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}