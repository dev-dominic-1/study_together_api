using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using study_together_api.Data;
using study_together_api.Entities;

namespace study_together_api.Filters;

public class ExceptionHandler : IExceptionFilter
{

    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception.Message);
        _logger.LogError(context.Exception.StackTrace);
        context.Result = new StatusCodeResult(500);
    }
}