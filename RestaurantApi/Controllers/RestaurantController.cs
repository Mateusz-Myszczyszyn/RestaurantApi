using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;
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
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants = _context
                .Restaurants
                .Include(r=>r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);  
            return Ok(restaurantsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _context
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);

            if(restaurant is null)
            {
                return NotFound("Restaurant does not exist");
            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restaurantDto);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return Created($"/api/restaurant/{restaurant.Id}",null);
        }
    }
}
