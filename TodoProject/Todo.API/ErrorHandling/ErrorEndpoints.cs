using System;
namespace Todo.API.ErrorHandling
{
    public static class ExceptionHandling
    {
        public static void HandleApplicationException(IApplicationBuilder builder)
        {
            builder.Run(Problem);
        }

        private static async Task Problem(HttpContext context)
        {
            await Results.Problem(
                detail: "Internal server error",
                statusCode: StatusCodes.Status500InternalServerError
            ).ExecuteAsync(context);
        }
    }
}