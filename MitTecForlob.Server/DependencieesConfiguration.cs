using Logic;
using Logic.Interfaces;
using Logic.Models_Logic;
using Logic.Models_Logic.Table_Repo;
using Microsoft.EntityFrameworkCore;
namespace MitTecForlob.Server
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection GetConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DBcontext>(con => con
                                                     .UseSqlServer(configuration.GetConnectionString("Connection"))
                                            );

            return services;

        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDataCollection, DataCollection>();
            return services;

        }
    }
}
