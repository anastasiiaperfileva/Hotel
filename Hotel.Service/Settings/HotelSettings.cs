namespace Hotel.Service.Settings;

public class HotelSettings
{
    public Uri ServiceUri { get; set; }
    public string HotelDbContextConnectionString { get; set; }
    public int MinimumTrainerAge { get; set; } = 18;
    public string IdentityServerUri { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}