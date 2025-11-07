using Hotel.Service.Settings;
using Hotel.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, HotelSettings settings)
    {
        services.AddDbContextFactory<HotelDbContext>(
            options => { options.UseNpgsql(settings.HotelDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<HotelDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); 
    }
}