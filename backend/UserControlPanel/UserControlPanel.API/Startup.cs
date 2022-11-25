using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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

            services.AddEndpointsApiExplorer();

            services.AddControllers();            
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.EnvironmentName)
            //{
            //    app.UseDeveloperExceptionPage();
            //}

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

        }
    }
}
