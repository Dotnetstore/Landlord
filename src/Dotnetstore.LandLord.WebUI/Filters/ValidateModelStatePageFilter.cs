using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnetstore.LandLord.WebUI.Filters;

public class ValidateModelStatePageFilter : IPageFilter
{
    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }
    
    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerInstance is PageModel page &&
            !page.ModelState.IsValid)
        {
            context.Result = page.Page();
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }
}