using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.Services;
using Modules.User.Domain.IDomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ITimeConverter, Services.TimeConverter>();
            return services;
        }
    }
}
