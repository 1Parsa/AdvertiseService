namespace AdvertiseService.Presentation.Middleware
{
    public class ExceptionHandlingMiddleware

    {

        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)

        {

            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)

        {

            try

            {

                await _next(context);

            }

            catch (Exception ex)

            {

                await HandleExceptionAsync(context, ex);

            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)

        {

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync("خطای سرور رخ داده است");

        }

    }
}
