using System.Web.Http;
using WebApiValidation.Models;

namespace WebApiValidation.Controllers
{
    [RoutePrefix("CustomerValidate")]
    public class CustomerValidateController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CustomerValidateObject customer)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
