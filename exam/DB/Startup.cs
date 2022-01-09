using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DB.Database;
using DB.Database.MonsterDirectory;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services
            .AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("DatabaseConnection"))
                    .UseValidationCheckConstraints())
            .AddScoped<IMonsterRepository, MonsterRepository>()
            .AddSwaggerGen(c =>  c.SwaggerDoc("v1", new OpenApiInfo { Title = "DB", Version = "v1" }))
            .AddControllers();
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB v1"));
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}