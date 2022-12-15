using System.Data;
using CrossCutting.DataObjects;
using Dapper;

namespace DataStoring.Repositories;

public class ProjectRepository :IRepository<Project>
{
    private IDbConnection _connection;

    public ProjectRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IQueryable<Project> Load()
    {
        using (_connection)
        {
            return _connection.Query<Project>("SELECT * FROM project").AsQueryable();
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