using Shared;
using System;

namespace Model
{

    public class Ustensil //: IUstensil
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dish Dish { get; set; }

        public Ustensil() { }

        public Ustensil(Dish dish, String name)
        {
            this.Dish = dish;
            this.Name = name;
        }
    }
}