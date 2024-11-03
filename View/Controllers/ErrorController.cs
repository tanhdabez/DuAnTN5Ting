using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    [Route("Error")]
    public class ErrorController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (statusCode == 403)
            {
                return View("403");
            }
            return View("Error");
        }
    }

}
