using CarStoreApplication.Services;
using CarStoreCore.Models;
using CarStoreWEB.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController
    {
        private readonly ICarService _caveService;

        public CarsController(ICarService caveService)
        {
            _caveService = caveService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarsResponce>>> GetCars()
        {
            var cars = await _caveService.GetAll();
            var responce = cars.Select(c => new CarsResponce(c.Id, c.Name, c.Model, c.Description, c.Price));

            return new ActionResult<IEnumerable<CarsResponce>>(responce.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateCar([FromBody]CarsRequest request)
        {
            var (car, err) = Car.CreateCar(
                Guid.NewGuid(),
                request.Name,
                request.Model,
                request.Discription,
                request.Price
                );

            if(!string.IsNullOrEmpty(err)) {
                return new ActionResult<string>(err);
            }

            await _caveService.Create(car);

            return new ActionResult<string>(request.Name);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCars(Guid carId, [FromBody] CarsRequest request)
        {
            await _caveService.Update(carId, request.Name, request.Model, request.Discription, request.Price);
            return new ActionResult<Guid>(carId);
        }

        [HttpDelete("{id:guid}")]
        public async  Task<ActionResult<Guid>> DeleteCar(Guid guid)
        {
            return await _caveService.Delete(guid);
        }
    }
}
