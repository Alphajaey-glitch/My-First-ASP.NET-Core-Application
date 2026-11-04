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
                context.Response.Headers["Contemt-type"] = "text/html";
                if (context.Request.Method == "GET")
                {
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        string id = context.Request.Query["id"];

                        await context.Response.WriteAsync($"<p>{id}</p>");
                    }
                }
            });

            app.Run();
        }
    }
}
