using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.DI
{
    public static class ApplicationServiceregistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddMediatR(x => {
                x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });


            return services;
        }
    }
}
