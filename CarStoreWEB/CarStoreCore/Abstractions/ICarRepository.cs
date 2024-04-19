using CarStoreCore.Models;

namespace CarStoreDataAccess.Repositories
{
    public interface ICarRepository
    {
        Task<Guid> Create(Car car);
        Task<Guid> Delete(Guid id);
        Task<List<Car>> Get();
        Task<Guid> Update(Guid id, string name, string model, string discription, decimal price);
    }
}