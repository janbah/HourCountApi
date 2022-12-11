using CrossCutting.DataObjects;
using HourCountApi.ViewModels;

namespace WorkingTimeManagement;

public interface IWorkingTimeManager
{
    List<WorkingTime> GetWorkingTime(DateTime date, Employee employee);
    List<WorkingTimeSum> GetWorkingTimeOverView(Employee employee);
    IQueryable<Category> GetCategoryItems();
    IQueryable<Project> GetProjectItems();
    void Add(WorkingTimeDto workingTimeDto);
    void Update(WorkingTimeDto workingTimeDto);
    void Delete(int id);
    IEnumerable<WorkingTime> GetWorkingTimeTest();
}