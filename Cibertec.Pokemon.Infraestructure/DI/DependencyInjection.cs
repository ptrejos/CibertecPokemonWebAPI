using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Infraestructure.DI
{
    public static class DependencyInjection
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration config)
        {

            var serilogLogger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.File(config.GetSection("LogSettings:FileName").Value, rollingInterval: RollingInterval.Day).CreateLogger();


            var serilog2 = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();




            services.AddLogging(x => {


                x.AddSerilog(logger: serilog2, dispose: true);
                x.AddSerilog(logger: serilogLogger, dispose: true);
            });



        }
    }
}
