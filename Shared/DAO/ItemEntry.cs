using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    class ItemEntry
    {
        [Key]
        ItemType ItemType { get; set; }
        int Quantity { get; set; }
    }
}
