using CrossCutting.DataTransferObjects;

namespace DataStoring.RepositoryContracts;

public interface IRepository<T>
{
    IQueryable<T> Load();
    int Insert(WorkingTimeDto workingTimeDto);
    void Update(WorkingTimeDto workingTimeDto);
    void Delete(int id);
}