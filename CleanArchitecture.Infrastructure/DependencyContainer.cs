using VehicleData.Application.Interfaces;
using VehicleData.Application.Services;
using VehicleData.Domain.Interfaces;
using VehicleData.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleData.Infrastructure
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
        }
    }
}
