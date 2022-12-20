using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace HourCountTests;

public class CustomWorkingTimeApiFactory : WebApplicationFactory<HourCountApi.Controller.WorkingTimeController>
{
    private readonly string _connectionString = "Server=localhost;Database=hour_count_test;User Id=sa;Password=Holzwiese22;Encrypt=False;";

    public CustomWorkingTimeApiFactory()
    {
        Client = CreateClient();
    }

    public HttpClient Client { get; private  set; }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var connection = new SqlConnection(_connectionString);
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IDbConnection));
            services.AddTransient<IDbConnection>((_) =>
                connection);
        });
    }


    
}