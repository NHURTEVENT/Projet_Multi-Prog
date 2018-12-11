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
    public class UtensilEntry
    {
        //public int UtensilEntryId { get; set; }
        //[Index("IX_Utensil",IsUnique = true)]
        [Key]
        public UtensilType UtensilType { get; set; }
        public int Quantity { get; set; }

        public UtensilEntry(UtensilType utensil, int quantity)
        {
            UtensilType = utensil;
            Quantity = quantity;
        }

        public UtensilEntry() { }
    }
}
