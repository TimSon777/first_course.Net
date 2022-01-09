using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error")
                    .UseHsts();
            
            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}