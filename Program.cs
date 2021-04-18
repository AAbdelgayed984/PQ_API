using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PQ_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((_, builder) =>
                {
                        builder.AddFile("Logs/PQ_API-{Date}.json", isJson: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                        webBuilder.UseStartup<Startup>();
                });
   }
}
