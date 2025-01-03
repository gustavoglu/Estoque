using Estoque.Presentation.Api.ViewModels;

namespace Estoque.Presentation.Api.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response
                    .WriteAsJsonAsync(ApiResult.ErrorResult(ex.Message));
            }
        }
    }
}
