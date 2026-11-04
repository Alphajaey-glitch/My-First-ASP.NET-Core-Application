namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async (HttpContext context) =>
            {
                context.Response.Headers["MyKey"] = "My Value";
                context.Response.Headers["Content-Type"] = "text/html";
                context.Request.Headers["Server"] = "My Server";

                await context.Response.WriteAsync("<h1>Hello</h1>");
                await context.Response.WriteAsync("<h2>World!<h2>");
            });

            app.Run();
        }
    }
}
