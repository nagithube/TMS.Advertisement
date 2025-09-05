using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.DataAccess.Contexts;

namespace TMS.Advertisement.DataAccess;

public static partial class Startup
{
    public static IServiceCollection UseContextStartup(this IServiceCollection services) =>
        services.AddDbContext<PostgreSqlTmsContext>(
            options =>
                options.UseNpgsql(new ConfigurationManager().GetConnectionString("PostreSql_Connection_String")));
}