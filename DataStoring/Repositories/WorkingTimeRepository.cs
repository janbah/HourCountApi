using System.Data;
using CrossCutting.DataObjects;
using Dapper;

namespace DataStoring.Repositories;

public class WorkingTimeRepository : IRepository<WorkingTime>
{
    private readonly IDbConnection _connection;
    
    public WorkingTimeRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IQueryable<WorkingTime> Load()
    {
        var workingTimes = new List<WorkingTime>();
        using (_connection)
        {
            string sql = @"select

                wt.id
                ,wt.time_entry timeEntry
                ,wt.date
                ,wt.comment
                ,wt.employee_id
                ,wt.category_id

                ,e.id
                ,e.name name
                ,e.is_active

                ,c.id
                ,c.name name

                ,p.id
                ,p.start_date startDate
                ,p.end_date endDate
                ,p.customer_id
                ,p.fair_id

                ,c2.id
                ,c2.name
                ,c2.long_name longname

                ,f.id
                ,f.name
                ,f.long_name longname
                ,f.start_date startdate
                ,f.end_date enddate
                ,f.town

            from working_time wt
            inner join employee e on e.id = wt.employee_id
            inner join category c on c.id = wt.category_id
            inner join project p on p.id = wt.project_id
            inner join customer c2 on c2.id = p.customer_id
            inner join fair f on f.id = p.fair_id";
            
            workingTimes = (List<WorkingTime>)_connection.Query<WorkingTime,Employee, Category, Project, Customer, Fair, WorkingTime>(
                sql, 
                (workingTime, employee, category, project, customer, fair) =>
                {
                    workingTime.Employee = employee;
                    workingTime.Category = category;
                    workingTime.Project = project;
                    workingTime.Project.Customer = customer;
                    workingTime.Project.Fair = fair;
                    
                    return workingTime;
                },
                splitOn:"category_id, is_active, name, fair_id, longname"
            
            );
        }
        return workingTimes.AsQueryable();
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