using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetbyId(int id);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto dto);
    }
}