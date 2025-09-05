using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.DataAccess;
using TMS.Advertisement.Infrastructure.Startup;

namespace TMS.Advertisement.Startup;

public static partial class Startup
{
    public static IServiceCollection UseStartup(this IServiceCollection services) => 
        services
            .UseContextStartup()
            .UseInfrastructureStartup();
}