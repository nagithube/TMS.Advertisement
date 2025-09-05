using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.Domain.Startup;
using TMS.Advertisement.Infrastructure.Startup;

namespace TMS.Advertisement.Startup;

public static partial class Startup
{
    public static IServiceCollection UseStartup(this IServiceCollection services) =>
        services
            .AddDomainStartup()
            .UseInfrastructureStartup();
}