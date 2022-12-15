using System.Data;
using CrossCutting.DataObjects;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DataStoring.Repositories;

public class CategoryRepository :IRepository<Category>
{
    private IDbConnection _connection;
    public CategoryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IQueryable<Category> Load()
    {
        using (_connection)
        {
            return _connection.Query<Category>("Select * From Category").AsQueryable();
        }
    }

    public int Insert(WorkingTimeDto workingTimeDto)
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