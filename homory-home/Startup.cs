using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace homory.home
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHsts(options => { options.Preload = true; options.IncludeSubDomains = true; options.MaxAge = TimeSpan.MaxValue; });
            services.AddCors(options => { options.AddPolicy(nameof(CorsPolicy), builder => { builder.WithOrigins(Configuration.GetSection("hosts").GetChildren().Select(config => $"https://{config.Value}").ToArray()).AllowAnyHeader().AllowAnyMethod(); }); });
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseHsts();
            application.UseCors(nameof(CorsPolicy));
            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseRouting();
            application.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}
