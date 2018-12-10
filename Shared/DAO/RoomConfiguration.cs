using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RoomConfiguration
    {
        public List<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        public List<ItemDBEntry> Items { get; set; }
        public List<TableDBEntry> TableDBEntries { get; set; }

        public RoomConfiguration(List<PersonnelDBEntry> personnelDBEntries, List<ItemDBEntry> items,List<TableDBEntry> tableDBEntries)
        {
            PersonnelDBEntries = personnelDBEntries;
            TableDBEntries = tableDBEntries;
            Items = items;
        }
    }
}
