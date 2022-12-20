using System.Data;
using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using Dapper;
using DataStoring.RepositoryContracts;

namespace DataStoring.DapperRepositories;

public class CategoryRepository :IRepository<Category>
{
    private readonly IDbConnection _connection;
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