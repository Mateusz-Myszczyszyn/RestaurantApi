using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;
using RestaurantApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]//self checking if model is valid(Model.isValid)
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        //[Authorize(Policy ="Atleast20")]
        [Authorize(Policy ="CreatedAtleast2Restaurants")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAll();

            return Ok(restaurantsDtos);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {

            var restaurant = _restaurantService.GetbyId(id);

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        //[Authorize(Roles ="Manager")]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {
     
           var id = _restaurantService.Create(dto);
           
            return Created($"/api/restaurant/{id}",null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _restaurantService.Delete(id);

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {

            _restaurantService.Update(id, dto);


            return Ok();
        }
    }
}
