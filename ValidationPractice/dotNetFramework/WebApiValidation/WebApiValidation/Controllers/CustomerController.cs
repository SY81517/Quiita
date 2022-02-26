using System.Web.Http;
using WebApiValidation.Models;

namespace WebApiValidation.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
