using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;

namespace WorkingTimeManagement;

public interface IWorkingTimeManager
{
    List<WorkingTime> GetWorkingTimesByDate(DateTime date, int employeeId);
    List<WorkingTimeSum> GetWorkingTimeSums(int employeeId);
    IQueryable<Category> GetCategoryItems();
    IQueryable<Project> GetProjectItems();
    int Add(WorkingTimeDto workingTimeDto);
    void Update(WorkingTimeDto workingTimeDto);
    void Delete(int id);
    WorkingTime GetWorkingTime(int id);
    IQueryable<WorkingTime> GetAll();
}