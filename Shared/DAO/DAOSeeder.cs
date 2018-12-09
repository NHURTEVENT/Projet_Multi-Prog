using Model;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DAOSeeder : DropCreateDatabaseIfModelChanges<ConfigurationContext>
    {
        public DAOSeeder(ConfigurationContext context)
        {
            Seed(context);
        }

        public void Seed(ConfigurationContext context)
        {
            /*
            var tableDBEntries = new List<TableDBEntry>{
                new TableDBEntry(2,1,1,1),
                new TableDBEntry(8,1,1,2),
                new TableDBEntry(4,1,2,2),
                
            };
            tableDBEntries.ForEach(t => context.Tables.Add(t));
            context.SaveChanges();

            var ItemDBEntries = new List<ItemDBEntry>
            {
                new ItemDBEntry(ItemType.BREAD_BASKETS,5),
                new ItemDBEntry(ItemType.WATER_BOTTLES,5),
                new ItemDBEntry(ItemType.TABLE_CLOTHES,10),
                new ItemDBEntry(ItemType.FLAT_PLATES,30)
            };
            ItemDBEntries.ForEach(i => context.Items.Add(i));
            context.SaveChanges();*/
            /*
            var PersonnelDBEntries = new List<PersonnelDBEntry>{
                new PersonnelDBEntry(PersonnelType.WAITER,4),
                new PersonnelDBEntry(PersonnelType.BUTLER,1),
                new PersonnelDBEntry(PersonnelType.ROOMCLERK,1),
                new PersonnelDBEntry(PersonnelType.HEADWAITER,2),
                new PersonnelDBEntry(PersonnelType.KITCHENCHEF,1),
                new PersonnelDBEntry(PersonnelType.KITCHENPARTYCHEF,2),
                new PersonnelDBEntry(PersonnelType.KITCHENCLERK,2),
                new PersonnelDBEntry(PersonnelType.DISHCLEANER,1)
            };
            PersonnelDBEntries.ForEach(e => context.PersonnelDBEntries.Add(e));
            context.SaveChanges();
            */
        }
    }
}
