using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.Services.Implementations;
using TMS.Advertisement.Services.Interfaces;

namespace TMS.Advertisement.Infrastructure.Startup;

public static partial class Startup
{
    public static IServiceCollection UseInfrastructureStartup(this IServiceCollection services) =>
        services
            .AddScoped<IAdvertisementService, AdvertisementService>();
}