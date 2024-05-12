using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CaseCracker.API.Attributes;

public class ValidationExceptionFormatterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context?.Exception is null) return;
        
        switch (context.Exception)
        {
            case ValidationException exception:
            {
                var objectResult = new ObjectResult(new GenericDto<bool?>
                {
                    IsSuccess = false,
                    Errors = exception.Errors.Select(x => x.ErrorMessage).ToList(),
                })
                {
                    StatusCode = 422
                };

                context.Result = objectResult;
                context.ExceptionHandled = true;
                break;
            }
        }
    }
}

public class GenericDto<T>
{
    public bool IsSuccess { get; set; } = true;
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
}