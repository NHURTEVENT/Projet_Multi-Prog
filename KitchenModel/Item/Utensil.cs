using Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Utensil : IUtensil
    {
        [Key]
        public string Name { get; set; }
        public Dish Dish { get; set; }

        public Utensil(String name)
        {
            Name = name;
            Dish = Dish.NONE;
        }
        /*
                public Utensil(Dish dish, String name)
                {
                    this.Dish = dish;
                    this.Name = name;
                }
        */
    }
}