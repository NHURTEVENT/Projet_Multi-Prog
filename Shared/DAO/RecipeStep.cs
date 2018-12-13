using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// Step of a given recipe
    /// </summary>
    public class RecipeStep
    {
        //Composed primary key
        //Dish this is a step of
        [Key, Column(Order = 0)]
        public Dish Dish { get; set; }
        //Step number
        [Key, Column(Order = 1)]
        public int Step { get; set; }
        //Description of the action to do
        public String Name { get; set; }
        //Foreign key, utensil to use
        public UtensilType UtensilType { get; set; }
        [ForeignKey("UtensilType")]
        public Drawer UtensilRef { get; set; }
        //Time to complete the step
        public int Duration { get; set; }

        public RecipeStep()
        {
        }

        public RecipeStep(Dish dish, int step, String name, UtensilType utensil, int duration)
        {
            Dish = dish;
            Step = step;
            Name = name;
            UtensilType = utensil;
            Duration = duration;
        }
    }
}
