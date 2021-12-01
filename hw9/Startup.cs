using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw9.Infrastructure.Calculator;
using hw9.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace hw9
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services
            .AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DbCalculation")))
            .AddTransient<IExpressionCalculator, ExpressionCalculator>()
            .AddTransient<ICashedCalculator, CashedCalculator>()
            .AddControllersWithViews();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error")
                    .UseHsts();
            
            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllerRoute(
                    "default", 
                    "{controller=Home}/{action=Index}/{id?}")
                );
        }
    }
}
