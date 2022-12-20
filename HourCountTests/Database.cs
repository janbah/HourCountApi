using System.Data.Common;
using CrossCutting.DataObjects;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HourCountTests;

public class Database
{
    private readonly string connectionString = "Server=localhost;Database=hour_count_test;User Id=sa;Password=Holzwiese22;Encrypt=False;";
    private DbConnection _connection = default!;


    public Database()
    {
        _connection = new SqlConnection(connectionString);
    }
    
    public void ResetDatabase()
    {
        
        string resetWorkingTime = File.ReadAllText(@"../../../Resources/resetDatabase.sql");
        _connection.Execute(resetWorkingTime);
    }

    public IEnumerable<WorkingTime> GetWorkingTimes()
    {
        string sql = @"select * from working_time";
        var result = _connection.Query<WorkingTime>(sql);
        
        return  result;
    }
}