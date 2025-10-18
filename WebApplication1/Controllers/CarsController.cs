using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<Car> GetAllRecord()
        {

            using (var context = new CarDbContext())
            {
                var cars = context.Cars.ToList();

                if (cars != null)
                {
                    return Ok( new { message = "Sikeres lekérdezés!", result = cars } );
                }

            }

            return BadRequest( new { message = "Sikertelen lekérdezés!" } );
            
        }


        [HttpGet("ById")]
        public ActionResult<Car> GetRecordById(int id)
        {

            using (var context = new CarDbContext())
            {
                var car = context.Cars.FirstOrDefault(car => car.Id == id);

                if (car != null)
                {
                    return Ok( new { message = "Sikeres lekérdezés!", result = car });
                }

            }

            return NotFound( new { message = "Sikertelen lekérdezés!" } );

        }


        [HttpPost]
        public ActionResult<Car> AddNewRecord(Car car)
        {

            using (var context = new CarDbContext())
            {
                var newCar = new Car
                {

                    Brand = car.Brand,
                    Type = car.Type,
                    Color = car.Color,
                    Year = car.Year

                };

                if(newCar != null)
                {
                    context.Cars.Add(newCar);
                    context.SaveChanges();
                    return StatusCode(201, newCar);
                }
                else
                {
                    return BadRequest(new { message = "Sikertelen hozzáadás!" });
                }
            }
        }

    }
}
