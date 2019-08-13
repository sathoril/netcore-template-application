using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateApplication.API.Extensions;
using TemplateApplication.API.StartupConfiguration;
using TemplateApplication.Data.Context;

namespace TemplateApplication.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            GlobalExceptionHandlerMiddlewareExtensions.AddGlobalExceptionHandlerMiddleware(services);
            InjectionConfig.Configure(services);

            services.AddDbContext<DatabaseContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DatabaseContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. (Middlewares)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            GlobalExceptionHandlerMiddlewareExtensions.UseGlobalExceptionHandlerMiddleware(app);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
