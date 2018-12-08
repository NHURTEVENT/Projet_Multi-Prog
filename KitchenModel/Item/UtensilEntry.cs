using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UtensilEntry
    {
        //public int UtensilEntryId { get; set; }
        //[Index("IX_Utensil",IsUnique = true)]
        [Key]
        public String Utensil { get; set; }
        public int Quantity { get; set; }

        public UtensilEntry(string utensil, int quantity)
        {
            Utensil = utensil;
            Quantity = quantity;
        }

        public UtensilEntry() { }
    }
}
