using CrossCutting.DataObjects;

namespace DataStoring.Repositories;

public class ProjectMockRepository : IRepository<Project>
{
    private IRepository<Customer> _customerRepo;
    private IRepository<Fair> _fairRepo;

    public ProjectMockRepository(IRepository<Customer> customerRepo, IRepository<Fair> fairRepo)
    {
        _customerRepo = customerRepo;
        _fairRepo = fairRepo;
    }

    public IQueryable<Project> Load()
    {
        
        
        Project project1 = new()
        {
            Id = 1,
            Customer = _customerRepo.Load().First(),
            Fair = _fairRepo.Load().First(),
            StartDate = new DateTime(2022,10,3),
            EndDate = new DateTime(2022,10,8)
            
        };
        
        Project project2 = new()
        {
            Id = 2,
            Customer = _customerRepo.Load().Where(c=>c.Id == 2).First(),
            Fair = _fairRepo.Load().Where(f=>f.Id == 2).First(),
            StartDate = new DateTime(2022,4,22),
            EndDate = new DateTime(2022,4,28)

        };
        List<Project> projectList = new() { project1, project2 };

        return projectList.AsQueryable();
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