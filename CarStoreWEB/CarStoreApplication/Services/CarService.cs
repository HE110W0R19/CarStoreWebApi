using CarStoreCore.Models;
using CarStoreDataAccess.Repositories;

namespace CarStoreApplication.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository) 
        {
            _carRepository = carRepository;
        }

        //GET
        public async Task<List<Car>> GetAllCars()
        {
            return await _carRepository.Get();
        }

        //POST
        public async Task<Guid> CreateCar(Car car)
        {
            return await _carRepository.Create(car);
        }

        //PUT
        public async Task<Guid> UpdateCar(Guid id, string name, string model, string discription, decimal price)
        {
            return await _carRepository.Update(id, name, model, discription, price);
        }

        //DELETE
        public async Task<Guid> DeleteCar(Guid id)
        {
            return await _carRepository.Delete(id);
        }
    }
}
