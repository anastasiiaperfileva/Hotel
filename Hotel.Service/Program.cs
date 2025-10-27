using Hotel.Service.Settings;
using Hotel.Service.IoC;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = HotelSettingsReader.Read(configuration);
var builder = WebApplication.CreateBuilder(args);

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);



app.Run();

