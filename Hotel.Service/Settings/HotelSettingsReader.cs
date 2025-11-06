namespace Hotel.Service.Settings;

public static class HotelSettingsReader
{
    public static HotelSettings Read(IConfiguration configuration)
    {
        return new HotelSettings()
        {
            ServiceUri = configuration.GetValue<Uri>("Uri"),
            HotelDbContextConnectionString = configuration.GetValue<string>("HotelDbContext"),
        };
    }
}