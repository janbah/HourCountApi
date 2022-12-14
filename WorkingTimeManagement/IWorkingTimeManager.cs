using CrossCutting.DataObjects;
using HourCountApi.ViewModels;

namespace WorkingTimeManagement;

public interface IWorkingTimeManager
{
    List<WorkingTime> GetWorkingTimesByDate(DateTime date, Employee employee);
    List<WorkingTimeSum> GetWorkingTimeOverView(Employee employee);
    IQueryable<Category> GetCategoryItems();
    IQueryable<Project> GetProjectItems();
    int Add(WorkingTimeDto workingTimeDto);
    void Update(WorkingTimeDto workingTimeDto);
    void Delete(int id);
    WorkingTime GetWorkingTime(int id);
}