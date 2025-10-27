namespace Hotel.Service.Settings;

public static class HotelSettingsReader
{
    public static HotelSettings Read(IConfiguration configuration)
    {
        return new HotelSettings()
        {
            ServiceUri = configuration.GetValue<Uri>("Uri"),
            HotelDbContextConnectionString = configuration.GetValue<string>("HotelDbContext"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
            ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
        };
    }
}