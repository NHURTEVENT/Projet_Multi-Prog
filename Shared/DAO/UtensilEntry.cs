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
   
    [Obsolete("Not used anymore, use Drawer instead", true)]
    public class UtensilEntry
    {
        
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
