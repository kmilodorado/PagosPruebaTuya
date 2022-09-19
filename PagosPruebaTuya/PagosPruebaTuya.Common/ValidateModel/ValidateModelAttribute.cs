using Microsoft.AspNetCore.Mvc.Filters;

namespace PagosPruebaTuya.Common.ValidateModel
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new ValidationFailedResult(context.ModelState);
        }
    }
}
