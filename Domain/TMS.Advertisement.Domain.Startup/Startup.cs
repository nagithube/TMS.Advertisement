using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.Domain.UseCases;

namespace TMS.Advertisement.Domain.Startup;

public static partial class Startup
{
    public static IServiceCollection AddDomainStartup(this IServiceCollection services) =>
        services
            .AddScoped<GetAdvertisementsByUserIdUseCase>();
}