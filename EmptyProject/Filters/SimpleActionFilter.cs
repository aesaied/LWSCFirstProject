using EmptyProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EmptyProject.Filters
{
    public class SimpleActionFilter : ActionFilterAttribute
    {
        private readonly IServiceA _serviceA;

        public SimpleActionFilter(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine($"This Event Fired: OnActionExecuting {filterContext.RouteData.Values["Controller"]} {filterContext.RouteData.Values["Action"]}");

            Debug.WriteLine(_serviceA.GetMsg());
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {

                if(filterContext.Exception is NotImplementedException)
                {
                    filterContext.Result = new RedirectToActionResult("Index", "Home",null); //new ContentResult() {  Content= "Under Contruction" , StatusCode=200};

                    filterContext.ExceptionHandled= true;
                }
            }


            Debug.WriteLine("This Event Fired: OnActionExecuted");
            if (filterContext.Exception != null)
            {

                Debug.WriteLine("Fail");
                
            }
            else
            {
                Debug.WriteLine("Success");
            }
        }
    }

}
