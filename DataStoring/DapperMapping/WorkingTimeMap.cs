using CrossCutting.DataObjects;
using Dapper.FluentMap.Mapping;

namespace DataStoring.DapperMapping;

public class WorkingTimeMap: EntityMap<WorkingTime>
{
    public WorkingTimeMap()
    {
        Map(i => i.Id).ToColumn("workingTimeId");
        Map(i => i.TimeEntry).ToColumn("zeitEintrag");
        Map(i => i.Date).ToColumn("date");
        Map(i => i.Comment).ToColumn("comment");
        
        // Map(i => i.Employee.Id).ToColumn("employeeId");
        // Map(i => i.Employee.Name).ToColumn("employeeName");
        // Map(i => i.Employee.is_active).ToColumn("is_active");
        //
        // Map(i => i.Category.Id).ToColumn("categoryId");
        // Map(i => i.Category.Name).ToColumn("categoryName");
        //
        // Map(i => i.Project.Id).ToColumn("projectId");
        // Map(i => i.Project.StartDate).ToColumn("projectStart");
        // Map(i => i.Project.EndDate).ToColumn("projectEnd");
        //
        // Map(i => i.Project.Customer.Id).ToColumn("customerId");
        // Map(i => i.Project.Customer.Name).ToColumn("customerName");
        // Map(i => i.Project.Customer.LongName).ToColumn("customerLongName");
        //
        // Map(i => i.Project.Fair.Id).ToColumn("fairId");
        // Map(i => i.Project.Fair.Name).ToColumn("fairName");
        // Map(i => i.Project.Fair.LongName).ToColumn("fairLongName");
        // Map(i => i.Project.Fair.StartDate).ToColumn("fairStart");
        // Map(i => i.Project.Fair.EndDate).ToColumn("fairEnd");
        // Map(i => i.Project.Fair.Town).ToColumn("town");
    }
}