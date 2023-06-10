﻿using RestaurantAPI.Entities;

namespace RestaurantAPI.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; } 
        public decimal Price { get; set; }  
        public int RestauyrantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
