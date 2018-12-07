using Shared;
using System;

namespace Model
{

    public class Ustensil //: IUstensil
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Dish dish { get; set; }

        public Ustensil(Dish dish, String name)
        {
            this.dish = dish;
            this.name = name;
        }
    }
}