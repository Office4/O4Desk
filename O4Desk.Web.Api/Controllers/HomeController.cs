using Microsoft.AspNetCore.Mvc;

namespace O4Desk.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Greetings from the O4 office.");
    }
}
