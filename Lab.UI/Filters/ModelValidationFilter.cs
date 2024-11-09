using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.UI.Filters
{
    /// <summary>
    /// Valida se os valores submetidos via formulário estão válidos.
    /// </summary>
    public class ModelValidationFilter : IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new PageResult();
                return;
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
           
        }
    }
}
