using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Description { get; set; }

        public decimal Price { get; set; }
    }
}
