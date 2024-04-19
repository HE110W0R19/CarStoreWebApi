using CarStoreCore.Models;
using CarStoreDataAccess.Repositories;

namespace CarStoreApplication.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        //GET
        public async Task<List<Car>> GetAll()
        {
            return await _carRepository.Get();
        }

        //POST
        public async Task<Guid> Create(Car car)
        {
            return await _carRepository.Create(car);
        }

        //PUT
        public async Task<Guid> Update(Guid id, string name, string model, string discription, decimal price)
        {
            return await _carRepository.Update(id, name, model, discription, price);
        }

        //DELETE
        public async Task<Guid> Delete(Guid id)
        {
            return await _carRepository.Delete(id);
        }
    }
}
