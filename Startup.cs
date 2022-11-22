using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using WebApplication3.Models;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IContainer container { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().
                            SetBasePath(env.ContentRootPath).
                            AddJsonFile("appsettings.json", false, true).
                            AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider  ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin().
                        AllowAnyHeader().
                        AllowAnyMethod().
                        AllowCredentials()
                        );
            });
            var builder = new ContainerBuilder();
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
            builder.Populate(services);

            container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                        IHostingEnvironment env,
                        ILoggerFactory loggerFctory,
                        IApplicationLifetime applicationLifetime)
        {


            app.UseCors("AllowAll");
            app.UseCors(options => options.WithOrigins("Access-Control-Allow-Origin","*"));
            app.Use(async (context, next) =>
            {
                await next();
                if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }

            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("CenterAssesorInfo", "CenterAssesorInfo",
                    defaults: new { controller = "CenterAssesorInfo" });
                routes.MapRoute("default", "{controller=CenterAssesorInfo}/{id?}");
            }   );
            applicationLifetime.ApplicationStopped.Register(() => container.Dispose());
        }

    }
}
