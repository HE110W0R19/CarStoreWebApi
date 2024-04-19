using CarStoreCore.Models;
using CarStoreDataAccess.TestDbContext;
using CarStoreDataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace CarStoreDataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        public readonly FirstTestDbContext _context;
        public CarRepository(FirstTestDbContext context)
        {
            _context = context;
        }

        //GET
        public async Task<List<Car>> Get()
        {
            var carEntities = await _context.Cars
                .AsNoTracking().ToListAsync();

            #pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            var cars = carEntities.Select
                (c => Car.CreateCar(c.Id, c.Name, c.Model, c.Description, c.Price).Car)
                .ToList();
            #pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            return cars;
        }

        //POST
        public async Task<Guid> Create(Car car)
        {
            var carEntity = new CarEntity
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                Description = car.Description,
                Price = car.Price,
            };

            await _context.Cars.AddAsync(carEntity);
            await _context.SaveChangesAsync();

            return carEntity.Id;
        }

        //PUT
        public async Task<Guid> Update(Guid id, string name, string model, string discription, decimal price)
        {
            await _context.Cars.Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Model, b => model)
                .SetProperty(b => b.Description, b => discription)
                .SetProperty(b => b.Price, b => price));
            return id;
        }

        //DELETE
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Cars.Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
