using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetbyId(int id);
        bool Delete(int id);
        bool Update(int id, UpdateRestaurantDto dto);
    }
}