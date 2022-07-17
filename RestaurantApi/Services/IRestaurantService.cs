using RestaurantApi.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto,int userId);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetbyId(int id);
        void Delete(int id, ClaimsPrincipal user);
        void Update(int id, UpdateRestaurantDto dto,ClaimsPrincipal user);
    }
}