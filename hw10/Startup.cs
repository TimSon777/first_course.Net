using hw10.Domain.Calculator;
using hw10.Services.Calculator;
using hw10.Services.Database;
using hw10.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hw10
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services
            .AddTransient<IExceptionHandler, ExceptionHandler>()
            .AddTransient<IExpressionVisitor, CalculatorVisitor>()
            .AddTransient<ICashedCalculator, CashedCalculator>()
            .AddTransient<IExpressionCalculator, ExpressionCalculator>()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DbCalculation")))
            .AddControllersWithViews();
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }
            
            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
