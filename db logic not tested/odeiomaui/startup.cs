using Microsoft.Extensions.DependencyInjection;

public class Startup : IStartup
{
    public void Configure(IAppHostBuilder appBuilder)
    {
        appBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<DatabaseContext>(_ =>
                new DatabaseContext("Host=database-1.cy9jxemryba8.us-east-2.rds.amazonaws.com;Port=5432;Database=PontoTech;Username=postgres;Password=Mauielixo;"));
        });
    }
}