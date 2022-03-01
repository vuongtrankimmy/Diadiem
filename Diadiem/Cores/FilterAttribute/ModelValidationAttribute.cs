using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cores.FilterAttribute
{
    /// <summary>
    /// Model Validation Attribute
    /// </summary>
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// Using ActionFilters to Remove Duplicated Code Filters in ASP.NET Core allows us to run some code prior to or after the specific stage in a request pipeline.Therefore, we can use them to execute validation actions that we need to repeat in our action methods.When we handle a PUT or POST request in our action methods, we need to validate our model object as we did in the Actions part of this article.As a result, that would cause the repetition of our validation code, and we want to avoid that(Basically we want to ///avoid any code repetition as much as we can).
        /// </summary>
        /// <param name="context">The context.</param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState); // returns 400 with error
            }
        }
    }
}
