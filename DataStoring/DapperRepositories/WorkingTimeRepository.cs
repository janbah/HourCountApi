using System.Data;
using CrossCutting.DataObjects;
using Dapper;
using Dapper.Contrib.Extensions;

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

                ,e.id --employeeId
                ,e.name --employeeName
                ,e.is_active

                ,c.id --categoryId
                ,c.name --categoryName    

                ,p.id --projectId
                ,p.start_date startDate
                ,p.end_date endDate
                ,p.customer_id
                ,p.fair_id

                ,c2.id --customerId
                ,c2.name --customerName
                ,c2.long_name longName

                ,f.id
                ,f.name
                ,f.long_name longName
                ,f.start_date startDate
                ,f.end_date endDate
                ,f.town

            from working_time wt
            inner join employee e on e.id = wt.employee_id
            inner join category c on c.id = wt.category_id
            inner join project p on p.id = wt.project_id
            inner join customer c2 on c2.id = p.customer_id
            inner join fair f on f.id = p.fair_id";

           // workingTimes = (List<WorkingTime>)_connection.Query(sql);

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
                 splitOn:"id, id, id, id, id"
            
             );
        }
        return workingTimes.AsQueryable();
    }

    public int Insert(WorkingTimeDto workingTimeDto)
    {
        using (_connection)
        {
            string sql = @"
                    insert into working_time (date, time_entry, project_id, category_id, employee_id, comment)  
                    values (@Date, @TimeEntry, @ProjectId, @CategoryId, @EmployeeId, @Comment);
                    SELECT CAST (SCOPE_IDENTITY() AS int )
                    ";
            return _connection.ExecuteScalarAsync<int>(sql, workingTimeDto).Result;
        }
    }

    public void Update(WorkingTimeDto workingTimeDto)
    {
        const string sql = @"
                    update working_time set time_entry = @TimeEntry, project_id = @ProjectId, category_id = @CategoryId, employee_id = @EmployeeId, comment = @Comment where id = @Id";
        _connection.Execute(sql, workingTimeDto);
    }

    public void Delete(int id)
    {
        using (_connection)
        {
            const string sql = "delete from working_time where id = @Id";
            int rowsAffected = _connection.Execute(sql, new{Id = id});
        }
    }
}