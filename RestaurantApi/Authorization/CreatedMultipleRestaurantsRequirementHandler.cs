﻿using Microsoft.AspNetCore.Authorization;
using RestaurantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Authorization
{
    public class CreatedMultipleRestaurantsRequirementHandler : AuthorizationHandler<CreatedMultipleRestaurantsRequirement>
    {
        private readonly RestaurantDbContext _context;

        public CreatedMultipleRestaurantsRequirementHandler(RestaurantDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleRestaurantsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c=>c.Type==ClaimTypes.NameIdentifier).Value);
            var countCreatedRestaurants = _context
                .Restaurants
                .Count(r => r.CreatedById == userId);

            if(countCreatedRestaurants >= requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
