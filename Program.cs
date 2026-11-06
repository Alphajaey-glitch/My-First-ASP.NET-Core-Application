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
