using CrossCutting.DataObjects;

namespace DataStoring.Repositories;

public interface IRepository<T>
{
    IQueryable<T> Load();
    void Insert(WorkingTimeDto workingTimeDto);
    void Update(WorkingTimeDto workingTimeDto);
    void Delete(int id);
}