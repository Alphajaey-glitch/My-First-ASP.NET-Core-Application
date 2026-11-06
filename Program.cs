using Microsoft.Extensions.Primitives;

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
                string path = context.Request.Path;
                string method = context.Request.Method;

                context.Response.Headers["Content-Type"] = "text/html";
                context.Response.Headers["Server"] = "My Server";
                context.Response.Headers["MyValue"] = "My Value";

                await context.Response.WriteAsync($"<p>{path}</p>");
                await context.Response.WriteAsync($"<p>{method}</p>");

                await context.Response.WriteAsync($"<h1>Hello</h1>");
                await context.Response.WriteAsync($"<h2>World!</h2>");

                if (context.Request.Method == "GET")
                {
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        string id = context.Request.Query["id"];

                        await context.Response.WriteAsync($"<p>{id}</p>");
                    }

                }

                if (context.Request.Headers.ContainsKey("AuthorizationKey"))
                {
                    string auth = context.Request.Headers["AuthorizationKey"];

                    await context.Response.WriteAsync($"<p>{auth}</p>{Environment.NewLine}");
                }
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                if (queryDict.ContainsKey("firstName"))
                {
                    foreach(var firstName in queryDict["firstName"])
                    {
                        await context.Response.WriteAsync($"{firstName}{Environment.NewLine}");
                    }
                }
            });

            app.Run();
        }
    }
}
