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
            
            var ustensils = new List<Drawer>
            {
                new Drawer(UtensilType.FORK,10),
                new Drawer(UtensilType.SPORK,20),
                new Drawer(UtensilType.KNIFE,30),
                new Drawer(UtensilType.PAN,10)
            };
            ustensils.ForEach(u => context.Ustensils.Add(u));
            
            context.SaveChanges();
            
            var machines = new List<MachineDBEntry>
            {
                new MachineDBEntry("washing",10,1,30,1,3),
                new MachineDBEntry("washing",30,1,60,1,3)
            };
            machines.ForEach(m => context.Machines.Add(m));
            context.SaveChanges();
            */
            /*
            var recipes = new List<RecipeStep>
            {
                new RecipeStep(Dish.FRENCHFRIES,1,"cut the popatoes",UtensilType.KNIFE,120),
                new RecipeStep(Dish.FRENCHFRIES,2,"fry the potatos", UtensilType.PAN,360)
            };
            recipes.ForEach(r => context.Recipes.Add(r));
            context.SaveChanges();
            */
            var dt = DateTime.Now;
            var stocks = new List<StockEntry>
            {

                new StockEntry(IngredientType.CHICKEN,20, new DateTime( dt.Ticks - dt.Ticks % TimeSpan.TicksPerSecond)),
                new StockEntry(IngredientType.FISH, 15,  new DateTime(dt.Ticks - dt.Ticks % TimeSpan.TicksPerSecond)),
                new StockEntry(IngredientType.PORK, 30,  new DateTime(dt.Ticks - dt.Ticks % TimeSpan.TicksPerSecond)),
                new StockEntry(IngredientType.POTATO,100, new DateTime(dt.AddDays(-7).Ticks - dt.AddDays(-7).Ticks % TimeSpan.TicksPerSecond))
            };
            stocks.ForEach(s => context.StockEntries.Add(s));
            context.SaveChanges();
        }

    }
}
