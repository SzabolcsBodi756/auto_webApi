using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                    return Ok();
                }

            }

            return BadRequest( new { message = "Sikertelen lekérdezés!" });
            
        }

    }
}
