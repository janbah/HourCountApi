using CrossCutting.DataObjects;
using DataStoring.Repositories;
using HourCountApi.ViewModels;

namespace WorkingTimeManagement;

public class WorkingTimeManager : IWorkingTimeManager
{
    private readonly IRepository<WorkingTime> _workingTimeRepo;
    private readonly IRepository<Category> _categoryRepo;
    private readonly IRepository<Project> _projectRepo;

    public WorkingTimeManager(IRepository<WorkingTime> workingTimeRepo, IRepository<Category> categoryRepo, IRepository<Project> projectRepo)
    {
        _workingTimeRepo = workingTimeRepo;
        _categoryRepo = categoryRepo;
        _projectRepo = projectRepo;
    }

    public IQueryable<WorkingTime> GetAll()
    {
        return _workingTimeRepo.Load();
    }

    public WorkingTime GetFirst()
    {
        return _workingTimeRepo.Load().FirstOrDefault();
    }

    public List<WorkingTime> GetWorkingTime(DateTime date, Employee employee)
    {
        return _workingTimeRepo.Load()
            .Where(w => 
                w.Employee.Name == employee.Name &&
                w.Date == date
                )
            .ToList();
    }

    public List<WorkingTimeSum> GetWorkingTimeOverView(Employee employee)
    {
        var result = _workingTimeRepo.Load()
            .Where(w=>w.Employee.Name == employee.Name)
            .GroupBy(w => w.Date
                , (date, entry) => new WorkingTimeSum(date, entry.Sum(e=>e.TimeEntry)))
            .ToList();
        
        return result;
    }

    public IQueryable<Category> GetCategoryItems()
    {
        return _categoryRepo.Load();
    }

    public IQueryable<Project> GetProjectItems()
    {
        return _projectRepo.Load();
    }

    public void Add(WorkingTimeDto workingTimeDto)
    {
        _workingTimeRepo.Insert(workingTimeDto);
    }

    public void Update(WorkingTimeDto workingTimeDto)
    {
        _workingTimeRepo.Update(workingTimeDto);
    }

    public void Delete(int id)
    {
        _workingTimeRepo.Delete(id);
    }

    public IEnumerable<WorkingTime> GetWorkingTimeTest()
    {
        return _workingTimeRepo.Load();
    }
}