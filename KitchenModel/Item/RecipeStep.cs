using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RecipeStep
    {
        [Key, Column(Order = 0)]
        public Dish Dish { get; set; }
        [Key, Column(Order = 1)]
        public int Step { get; set; }
        public String Name { get; set; }
        public UtensilType Utensil { get; set; }
        [ForeignKey("Utensil")]
        public UtensilEntry UtensilRef { get; set; }

        public int Duration { get; set; }

        public RecipeStep()
        {
        }

        public RecipeStep(Dish dish, int step, String name, UtensilType utensil, int duration)
        {
            Dish = dish;
            Step = step;
            Name = name;
            Utensil = utensil;
            Duration = duration;
        }
    }
}
