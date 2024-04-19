using CarStoreCore.Models;

namespace CarStoreApplication.Services
{
    public interface ICarService
    {
        Task<Guid> Create(Car car);
        Task<Guid> Delete(Guid id);
        Task<List<Car>> GetAll();
        Task<Guid> Update(Guid id, string name, string model, string discription, decimal price);
    }
}