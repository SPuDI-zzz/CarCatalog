using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Extensions;
using CarCatalog.Common.Responses;
using System.Text.Json;

namespace CarCatalog.Api.Configuration;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionsMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ErrorResponse response = null;
        try
        {
            await next.Invoke(context);
        }
        catch (ProcessException pe)
        {
            response = pe.ToErrorResponse();
        }
        catch (Exception pe)
        {
            response = pe.ToErrorResponse();
        }
        finally
        {
            if (response is not null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                await context.Response.StartAsync();
                await context.Response.CompleteAsync();
            }
        }
    }
}
