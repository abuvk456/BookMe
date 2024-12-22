using Microsoft.AspNetCore.Mvc;

namespace BookMe.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            switch(statuscode){
                case 404:
                    ViewBag.ErrorMessage = "Sorry, Hotel Not Found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Server or Data reading errors";
                    break;
            } 

            return View("NotFound");
        }
    }
}
