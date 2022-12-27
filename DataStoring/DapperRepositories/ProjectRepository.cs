using System.Data;
using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using Dapper;
using DataStoring.RepositoryContracts;

namespace DataStoring.DapperRepositories;

public class ProjectRepository :IRepository<Project>
{
    private IDbConnection _connection;

    public ProjectRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IQueryable<Project> Load()
    {
        List<Project> projects;
        using (_connection)
        {
            string sql = @"select
                p.id
                 ,customer_id
                 ,fair_id
                 ,p.start_date startDate
                 ,p.end_date endDate
                 ,f.id
                 ,f.name
                 ,town
                 ,f.start_date startDate
                 ,f.end_date endDate
                 ,f.long_name  longName
                 ,c.id
                 ,c.name
                 ,c.long_name longName
                from project p
                inner join fair f on p.fair_id = f.id
                inner join customer c on c.id = p.customer_id
            ";

            projects = _connection.Query<Project, Fair, Customer, Project>(
                sql, 
                (project, fair, customer) =>
                {
                    project.Fair = fair;
                    project.Customer = customer;

                    return project;
                }, 
                splitOn: "id,id"
            ).ToList();
            
            return projects.AsQueryable();
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