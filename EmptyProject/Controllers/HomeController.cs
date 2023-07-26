using EmptyProject.Filters;
using EmptyProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeService _empService;

        public HomeController(IEmployeeService empService)
        {
            _empService = empService;
        }

      
        public IActionResult Index([FromServices]IEmployeeService _empService)
        {
            ViewData["MyValue"] = "Extra value from  Index";
            //ViewBag.MyValue123 = 10;
            return View(_empService.GetAll());
        }

        public IActionResult Action2()
        {

            return Content("Action2 content");
            //return View();
        }


        public IActionResult Action3()
        {

            return  NotFound();
        }

        public IActionResult Action4()
        {
            return RedirectToAction("Index");
        }

        // [HttpGet("/action5/{id}/{x}")]

        [Route("home/action5/{id}/{x}")]
        //[Route("home/action-5/{id}/{x}")]

        public IActionResult Action5( int? id,int? x)
        {

            //var id1 = Request.Query["id"];
            if (x.HasValue==false)
            {
                return Redirect("http://google.com");

            }
            else
            {
                return Content($"The value of x = {x} and id = {id} ");
            }
        }

       [NonAction] 
        public void GetMsg()
        {
            var  x= "Welcome from GetMsg()";
        }


        //"Home/test-file"

        [ActionName("test-file")]
        public IActionResult TestFile()
        {

       //  return File()
            return PhysicalFile("C:\\test.jpg", "image/jpeg");
        }


        [ServiceFilter(typeof(SimpleActionFilter))]
        public IActionResult TestError()
        {
            throw new NotImplementedException();
        }

      
    }
}
