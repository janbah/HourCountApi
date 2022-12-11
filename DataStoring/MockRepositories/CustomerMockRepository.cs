using CrossCutting.DataObjects;

namespace DataStoring.Repositories;

public class CustomerMockRepository : IRepository<Customer>
{
    public IQueryable<Customer> Load()
    {
        
        Customer customer1 = new Customer()
        {
            Id = 0,
            Name = "Enercon Windcraft GmbH",
            LongName = "Enercon"
        };

        Customer customer2 = new Customer()
        {
            Id = 1,
            Name = "Stadtwerke Bielefeld GmbH",
            LongName = "StwBi"
        };
        
        Customer customer3 = new Customer()
        {
            Id = 2,
            Name = "Hella Autolichter GmbH",
            LongName = "Hella"
        };

        return new List<Customer>() { customer1, customer2, customer3 }.AsQueryable();
    }

    public void Insert(WorkingTimeDto workingTimeDto)
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