using Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Utensil : IUtensil
    {
        [Key]
        public UtensilType UtensilType {get;set;}
        public Dish Dish { get; set; }

        public Utensil(UtensilType type)
        {
            UtensilType = type;
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