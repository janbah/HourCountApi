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
}