using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tellbal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseNLog();
                    webBuilder.ConfigureLogging(options => options.ClearProviders());
                    //webBuilder.UseSentry(o =>
                    //{
                    //    o.Dsn = "https://905bc9ee46304d3cb4455c8323091b04:a06edd8e2b9a40ee8e29eb7d19322f0e@o936824.ingest.sentry.io/5888889";
                    //    // When configuring for the first time, to see what the SDK is doing:
                    //    o.Debug = true;
                    //    // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                    //    // We recommend adjusting this value in production.
                    //    o.TracesSampleRate = 1.0;
                    //});
                });
    }
}
