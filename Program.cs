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
                context.Response.Headers["Content-Type"] = "text/html";

                if (context.Request.Headers.ContainsKey("AuthorizationKey"))
                {
                    string auth = context.Request.Headers["AuthorizationKey"];

                    await context.Response.WriteAsync($"<p>{auth}</p>");
                }
                
            });

            app.Run();
        }
    }
}
