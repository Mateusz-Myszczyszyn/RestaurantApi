using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _context
                .Restaurants
                .ToList();

            return Ok(restaurants);
        }
    }
}
