using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using UserControlPanel.CrossCutting.DependencyInjection;
using UserControlPanel.Data;

namespace UserControlPanel.API
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

            services.AddSwaggerGen();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserControlPanel", Version = "v1", });
            });

            services.AddServicesFrom(new[]
            {
                "UserControlPanel.Application",
                "UserControlPanel.Data"
            });

            var applicationAssembly = AppDomain.CurrentDomain.Load("UserControlPanel.Application");
            services.AddMediatR(applicationAssembly);
            
            
            services.AddDbContext<UserControlPanelContext>(options =>
            {
                options.UseSqlServer("Server=localhost; Integrated Security =true; Database=UserControlPanel;Trusted_Connection=True; Encrypt=False; Persist Security Info =False;", x =>
                {
                    x.MigrationsAssembly("UserControlPanel.Data");
                });
            });

            services.AddAutoMapper(typeof(Application.AutoMapper.AutoMapperSetup));

            services.AddEndpointsApiExplorer();

            services.AddControllers();           

            services.AddMemoryCache();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {           

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .SetIsOriginAllowed(origin => true)
                          .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(x => x.SerializeAsV2 = true);

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UserControlPanelContext>();
                context.Database.Migrate();
            }

        }
    }
}
