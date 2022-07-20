using RestaurantApi.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        PagedResult<RestaurantDto> GetAll(RestaurantQuery query);
        RestaurantDto GetbyId(int id);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto dto);
    }
}