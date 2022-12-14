using CrossCutting.DataObjects;

namespace DataStoring.Repositories;

public class FairMockRepository : IRepository<Fair>
{
    public IQueryable<Fair> Load()
    {
        List<Fair> fairs = new();

        Fair fair1 = new()
        {
            Id = 1,
            LongName = "Hannover Messse",
            Town = "Hannover",
            Name = "HMI",
            StartDate = new(2022,3,16)
        };

        Fair fair2 = new()
        {
            Id = 2,
            Name = "Automechanica",
            StartDate = new(2022,5,10)
        };
        
        fairs.Add(fair1);
        fairs.Add(fair2);

        return fairs.AsQueryable();
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