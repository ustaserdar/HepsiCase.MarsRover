using HepsiCase.Application.Contracts;
using HepsiCase.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiCase.IoC
{
    public static class ServiceContainerBuilder
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();
            services.AddTransient<ICommander, Commander>();
        }
    }
}
