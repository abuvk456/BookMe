using BookMe.Models;
using BookMeModel;
using BookMeService.IBookService;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.DependencyResolver;
using System.Diagnostics;


namespace BookMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGridService _gridservice;

        public HomeController(ILogger<HomeController> logger, IGridService gridservice)
        {
            _logger = logger;
            _gridservice = gridservice;
        }

        public IActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult<GridItem[]>> GetAllHotels()
         {
            try
            {
                var result = await _gridservice.GetGridItem();
                return result;
                
            }
            
            catch (Exception Ex)
            {
                
                throw Ex;
                //return NotFound();

              
            }
            
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _gridservice.GetItemByIdAsync(id);
            //var item = 0;
            if (item == null)

                //return NotFound(new { message = "No Hotel Found" }); ;
                return NotFound();

            return View(item);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //    [HttpGet("Throw")]
        //    public IActionResult Throw() =>
        //throw new Exception("Sample exception.");



        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
    [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }





        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();



        //    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
        //    {
        //        public int Order => int.MaxValue - 10;

        //        public void OnActionExecuting(ActionExecutingContext context) { }

        //        public void OnActionExecuted(ActionExecutedContext context)
        //        {
        //            if (context.Exception is HttpResponseException httpResponseException)
        //            {
        //                context.Result = new ObjectResult(httpResponseException.Value)
        //                {
        //                    StatusCode = httpResponseException.StatusCode
        //                };

        //                context.ExceptionHandled = true;
        //            }
        //        }
        //    }




        //public async Task<IActionResult> HotelDetais(int id)
        //{
        //    var item = await _gridservice.GetItemByIdAsync(id);
        //    if (item == null)
        //        return NotFound();

        //    return View(item);
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}



    }
}