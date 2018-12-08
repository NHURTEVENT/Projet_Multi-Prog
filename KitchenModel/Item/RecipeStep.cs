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
        [Key]
        public Dish Dish { get; set; }
        [Key]
        public int Step { get; set; }
        [ForeignKey("Utensil")]
        public UtensilEntry Utensil { get; set; }
        public int Duration { get; set; }
    }
}
