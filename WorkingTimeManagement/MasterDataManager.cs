using CrossCutting.DataObjects;
using DataStoring.Repositories;

namespace WorkingTimeManagement;

public class MasterDataManager :IMasterDataManager
{
    
    private IRepository<Project> _projectRepo;

    public MasterDataManager(IRepository<Project> projectRepo)
    {
        _projectRepo = projectRepo;
    }

    public IQueryable<Project> GetProjects()
    {
        return _projectRepo.Load();
    }
}