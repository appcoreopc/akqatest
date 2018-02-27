using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AkqaDataServices.DataModel;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;

namespace AkqaWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<AkqaDataStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString(AppConstants.AkqaDataStore)));

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(AppConstants.WebApiVersion, new Info
                { Title = AppConstants.WebApiTitle, Version = AppConstants.WebApiVersion
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            loggerFactory.AddDebug();
           
            app.UseCors(option => option.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(AppConstants.SwaggerApiUrl, AppConstants.WebApiTitle);
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=swagger}/{action=Index}/{id?}");
            });

        }
    }
}
