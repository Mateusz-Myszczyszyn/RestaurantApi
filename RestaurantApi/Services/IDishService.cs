using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
    }
}