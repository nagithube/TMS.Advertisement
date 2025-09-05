using MassTransit;
using Microsoft.EntityFrameworkCore;
using TMS.Advertisement.Consumers;
using TMS.Advertisement.Controllers;
using TMS.Advertisement.DataAccess.Contexts;
using TMS.Advertisement.Startup;

namespace TMS.Advertisement;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy
                    .WithOrigins("http://localhost:44374")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        builder.Services.AddDbContext<PostgreSqlTmsContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostreSql_Connection_String")));

        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "TMS Advertisement API", Version = "v1" });
        });

        builder.Services.UseStartup();
        builder.Services.AddTransient<AdvertisementsController>();

        builder.Services.AddMassTransit(
            x =>
            {
                x.AddConsumer<ConfirmationRegistrationConsumer>();
                
                x.UsingRabbitMq(
                    (context, cfg) =>
                    {
                        cfg.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                        cfg.ReceiveEndpoint(
                            "user_logged_in",
                            e => { e.ConfigureConsumer<ConfirmationRegistrationConsumer>(context); });
                    });
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS Advertisement API v1");
                // Swagger будет доступен по http://localhost:PORT/swagger
            });
        }

        app.UseCors("AllowFrontend");
        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}