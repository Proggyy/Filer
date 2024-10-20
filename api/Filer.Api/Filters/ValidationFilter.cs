using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filer.Api.Filters;

public class ValidationFilterAttribute : Attribute,IActionFilter 
{
    public void OnActionExecuted(ActionExecutedContext context){}

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var dtoParam = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
        if (dtoParam is null){
            context.Result = new BadRequestObjectResult("Object is null.");
            return;
        }
        if(!context.ModelState.IsValid){
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}