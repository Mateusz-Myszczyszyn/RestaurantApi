﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Entities
{
    public class Dish
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Description { get; set; }

        public decimal Price { get; set; }

        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
