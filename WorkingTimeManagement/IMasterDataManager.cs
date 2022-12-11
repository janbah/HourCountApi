using CrossCutting.DataObjects;

namespace WorkingTimeManagement;

public interface IMasterDataManager
{
    IQueryable<Project> GetProjects();
}