﻿using RestaurantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi
{
    public class RestaurantSeeder
    {

        private readonly RestaurantDbContext _dbContext;
       public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kentucky Fried Chicken is an American fast food restaurant chain headquartered",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery=true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashvilel Hot Chicken",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001",
                    }
                },
                new Restaurant()
                {
                    Name="McDonald",
                    Category = "Fast Food",
                    Description = "McDonald's Corporation, incorporated on December 21,1964,operates and franchises",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001"

                    }
                }
            };

            return restaurants;
        }

    }
}
