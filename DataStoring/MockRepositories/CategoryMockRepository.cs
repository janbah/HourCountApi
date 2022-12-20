using CrossCutting.DataObjects;
using CrossCutting.DataTransferObjects;
using DataStoring.RepositoryContracts;

namespace DataStoring.MockRepositories;

public class CategoryMockRepository : IRepository<Category>
{
    public IQueryable<Category> Load()
    {
        Category entwurf = new()
        {
            Id = 1,
            Name = "Entwurf Briefing",
        };
        Category ausschreibung = new()
        {
            Id = 2,
            Name = "Ausschreibung",
        };
        
        Category uebergabe = new()
        {
            Id = 3,
            Name = "Übergabe",
        };

        List<Category> categoryList = new() { entwurf, ausschreibung, uebergabe };
        return categoryList.AsQueryable();
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