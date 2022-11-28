using System.Data;
using CrossCutting.DataObjects;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DataStoring.Repositories;

public class CategoryRepository :IRepository<Category> 
{
    public IQueryable<Category> Load()
    {
        string connectionString = "Server=localhost;Database=hour_count;User Id=sa;Password=Holzwiese22;Encrypt=False;";

        List<Category> categories = new List<Category>();
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            categories = db.Query<Category>("Select * From Category").ToList();
        }
        return categories.AsQueryable();
        
    }

    public void Insert(WorkingTimeDto workingTimeDto)
    {
        throw new NotImplementedException();
    }

    public void Update(WorkingTimeDto workingTimeDto)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}