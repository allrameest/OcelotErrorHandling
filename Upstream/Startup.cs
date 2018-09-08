using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Upstream
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            app.UseStatusCodePages("text/html", "<html><body>{0}</body></html>");
            app.Use(async (context, next) =>
            {
                await next();
                logger.LogInformation($"Middleware StatusCode: {context.Response.StatusCode}");
            });
            app.UseOcelot().Wait();
        }
    }
}