namespace Hotel.Service.Settings;

public static class HotelSettingsReader
{
    public static HotelSettings Read(IConfiguration configuration)
    {
        return new HotelSettings()
        {
            HotelDbContextConnectionString = configuration.GetConnectionString("HotelDbContext"),
        };
    }
}