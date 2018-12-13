using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// Contains all the all relevant information about the room
    /// the information is fetched in the database
    /// </summary>
    public class RoomConfiguration
    {
        //All the personnel of the room
        //gives the number of each type of personnel
        public List<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        //All the items in the room
        //gives the number of each type of item
        public List<ItemDBEntry> Items { get; set; }
        //All the infomation about the tables
        public List<TableDBEntry> TableDBEntries { get; set; }

        public RoomConfiguration(List<PersonnelDBEntry> personnelDBEntries, List<ItemDBEntry> items,List<TableDBEntry> tableDBEntries)
        {
            PersonnelDBEntries = personnelDBEntries;
            TableDBEntries = tableDBEntries;
            Items = items;
        }
    }
}
