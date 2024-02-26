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

    public async void OnException(ExceptionContext context)
    {
        var dbContext = context.HttpContext.RequestServices.GetService<DataContext>();
        dbContext?.Exceptions.Add(DataContextException.From(context.Exception));
        var promise = dbContext?.SaveChangesAsync();
        _logger.LogError(context.Exception.Message);
        if (promise is not null) await promise;
        context.Result = new StatusCodeResult(500);
    }
}