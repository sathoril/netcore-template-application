using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateApplication.Data.Repositories;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.API.StartupConfiguration
{
    public class InjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureServices(services);
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
