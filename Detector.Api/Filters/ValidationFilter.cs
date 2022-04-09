using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Detector.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public ValidationFilter()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
