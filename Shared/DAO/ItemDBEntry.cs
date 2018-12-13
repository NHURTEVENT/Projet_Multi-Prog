using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{    
    /// <summary>
     /// Stores a quantity of a given room item
     /// the quantity is stored in the database
     /// </summary>
    public class ItemDBEntry
    {
        //Primary key, the type of item (napkin, cup, etc)
        [Key]
        public ItemType ItemType { get; set; }
        //The quantity the restaurant possesses
        public int Quantity { get; set; }

        public ItemDBEntry()
        {
        }

        public ItemDBEntry(ItemType itemType, int quantity)
        {
            ItemType = itemType;
            Quantity = quantity;
        }
    }
}
