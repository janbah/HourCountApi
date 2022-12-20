using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using DataStoring.RepositoryContracts;

namespace DataStoring.MockRepositories;

public class WorkingTimeMockRepository : IRepository<WorkingTime>
{
    private readonly List<WorkingTime> _workingTimes;
    private readonly IRepository<Project> _projectRepo;

    public WorkingTimeMockRepository(IRepository<Project> projectRepo)
    {
        _projectRepo = projectRepo;
        _workingTimes = createWorkingTimes();
    }

    private List<WorkingTime> createWorkingTimes()
    {
        Project project1 = _projectRepo.Load().First();

        Project project2 = _projectRepo.Load().ToList()[1];

        Employee employee1 = new Employee()
        {
            Name = "Martin",
        };

        Category entwurf = new Category()
        {
            Id =1,
            Name = "Entwurf Briefing",
        };     
        
        Category ausschreibung = new Category()
        {
            Id = 2,
            Name = "Ausschreibung",
        };

        WorkingTime wt1 = new WorkingTime()
        {
            Id = 1,
            Date = new DateTime(2022, 4, 28),
            TimeEntry = 5,
            Project = project1,
            Employee = employee1,
            Category = entwurf
        };

        WorkingTime wt2 = new WorkingTime()
        {
            Id = 2,
            Date = new DateTime(2022, 4, 28),
            TimeEntry = 3,
            Project = project1,
            Employee = employee1,
            Category = entwurf,
            Comment = "Das ist ein Kommentar"
            
        };
        WorkingTime wt3 = new WorkingTime()
        {
            Id = 3,
            Date = new DateTime(2022, 4, 29),
            TimeEntry = 3,
            Project = project1,
            Employee = employee1,
            Category = ausschreibung
        };
        WorkingTime wt4 = new WorkingTime()
        {
            Id = 4,
            Date = new DateTime(2022, 4, 29),
            TimeEntry = 4,
            Project = project2,
            Employee = employee1,
            Category = entwurf
        };
        WorkingTime wt5 = new WorkingTime()
        {
            Id = 5,
            Date = new DateTime(2022, 4, 28),
            TimeEntry = 2,
            Project = project2,
            Employee = employee1,
            Category = entwurf
        };
        WorkingTime wt6 = new WorkingTime()
        {
            Id = 6,
            Date = new DateTime(2022, 4, 29),
            TimeEntry = 1,
            Project = project2,
            Employee = employee1,
            Category = entwurf
        };
        
        return new List<WorkingTime>() { wt1, wt2, wt3,wt4, wt5, wt6};
    }

    public IQueryable<WorkingTime> Load()
    {
        return _workingTimes.AsQueryable();
    }

    public int Insert(WorkingTimeDto workingTimeDto)
    {
        Console.WriteLine("Insert to Datastore");
        // WorkingTime wt = new();
        // wt.Id = workingTimes.Count + 1;
        // wt.TimeEntry = Convert.ToDecimal(workingTimeDto.TimeEntry);
        return 1;
    }

    public void Update(WorkingTimeDto workingTimeDto)
    {
        Console.WriteLine("Update entry in Datastore");
    }

    public void Delete(int id)
    {
        Console.WriteLine("Delete entry in Datastore");
    }
}