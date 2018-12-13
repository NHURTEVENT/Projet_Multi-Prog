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
    /// <summary>
    /// Singleton used to seeds the database with all the information needed for the simulation
    /// </summary>
    public sealed class DAOSeeder : DropCreateDatabaseIfModelChanges<ConfigurationContext>
    {

        private static DAOSeeder INSTANCE;

        public static DAOSeeder Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new DAOSeeder();
                }
                return INSTANCE;
            }
        }
        
        private DAOSeeder()
        {

        }

        private DAOSeeder(ConfigurationContext context)
        {
            Seed(context);
        }

        /// <summary>
        /// Seeds the database with all the information needed for the simulation
        /// </summary>
        public void Seed()
        {
            Seed(DAO.Instance.getContext());
        }

        /// <summary>
        /// Seeds the database with all the information needed for the simulation
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void Seed(ConfigurationContext context)
        {
            SeedPersonnel(context);
            SeedRoom(context);
            SeedKitchen(context);
        }

        /// <summary>
        /// Seeds the database with all the information to create the Room
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedRoom(ConfigurationContext context)
        {
            SeedItems(context);
            SeedTables(context);
        }

        /// <summary>
        /// Seeds the database with all the information to create the Kitchen
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedKitchen(ConfigurationContext context)
        {
            SeedMachines(context);
            SeedUtensils(context);
            SeedRecipes(context);
            SeedStock(context);
            
        }

        /// <summary>
        /// Seeds the database with all the information about the utensils
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedUtensils(ConfigurationContext context)
        {
            var ustensils = new List<Drawer>
            {
                new Drawer(UtensilType.FORK,10),
                new Drawer(UtensilType.SPORK,20),
                new Drawer(UtensilType.KNIFE,30),
                new Drawer(UtensilType.PAN,10)
            };
            ustensils.ForEach(u => context.Ustensils.Add(u));

            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the database with all the information about the tables
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedTables(ConfigurationContext context)
        {
            var tableDBEntries = new List<TableDBEntry>{
                new TableDBEntry(2,1,1,1),
                new TableDBEntry(8,1,1,2),
                new TableDBEntry(4,1,2,2),

            };
            tableDBEntries.ForEach(t => context.Tables.Add(t));
            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the database with all the information about the items
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedItems(ConfigurationContext context)
        {
            var ItemDBEntries = new List<ItemDBEntry>
            {
                new ItemDBEntry(ItemType.BREAD_BASKETS,5),
                new ItemDBEntry(ItemType.WATER_BOTTLES,5),
                new ItemDBEntry(ItemType.TABLE_CLOTHES,10),
                new ItemDBEntry(ItemType.FLAT_PLATES,30)
            };
            ItemDBEntries.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the database with all the information about the personnel
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedPersonnel(ConfigurationContext context)
        {
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
        }

        /// <summary>
        /// Seeds the database with all the information about the machines
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        public void SeedMachines(ConfigurationContext context)
        {
            var machines = new List<MachineDBEntry>
            {
                new MachineDBEntry(MachineType.WASHING,10,1,30,1,3),
                new MachineDBEntry(MachineType.DISHWASHER,30,1,60,1,3)
            };
            machines.ForEach(m => context.Machines.Add(m));
            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the database with all the recipes' steps
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        private void SeedRecipes(ConfigurationContext context)
        {
            var recipes = new List<RecipeStep>
            {
                new RecipeStep(Dish.FRENCHFRIES,1,"cut the potatoes",UtensilType.KNIFE,120),
                new RecipeStep(Dish.FRENCHFRIES,2,"fry the potatoes", UtensilType.PAN,360)
            };
            recipes.ForEach(r => context.Recipes.Add(r));
            context.SaveChanges();
        }

        /// <summary>
        /// Seeds the database with all the stock entries
        /// </summary>
        /// <param name="context">The updated DBContext</param>
        public void SeedStock(ConfigurationContext context)
        {
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