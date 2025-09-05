using TMS.Advertisement.Startup;

namespace TMS.Advertisement;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.UseStartup();

        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}