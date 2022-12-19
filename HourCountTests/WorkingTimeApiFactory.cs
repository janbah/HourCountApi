using System.Data;
using System.Data.Common;
using HourCountApi.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace HourCountTests;

public class CustomWorkingTimeApiFactory<T> : WebApplicationFactory<WorkingTimeController>
{
    private DbConnection _dbConnection = default!;

    public CustomWorkingTimeApiFactory()
    {
        string connectionString = "Server=localhost;Database=hour_count_test;User Id=sa;Password=Holzwiese22;Encrypt=False;";

        _dbConnection = new SqlConnection(connectionString);
        _dbConnection.Open();
        Client = CreateClient();
    }

    public HttpClient Client { get; private  set; }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IDbConnection));
            services.AddTransient<IDbConnection>((sp) =>
                _dbConnection);
        });
    }
    
}