using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ItemDBEntry
    {
        [Key]
        public ItemType ItemType { get; set; }
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
