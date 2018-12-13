using Shared.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;

namespace Shared {

    public sealed class DAO
    {
        private static DAO INSTANCE;
        private static Configuration CONFIGURATION;
        private static RoomConfiguration ROOM_CONFIGURATION;
        private static KitchenConfiguration KITCHEN_CONFIGURATION;

        private DAO()
        {

        }

        public static DAO Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new DAO();
                }
                return INSTANCE;
            }
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["KitchenContext"].ConnectionString.ToString();
        }

        public Boolean connect()
        {
            //create a new connection
            using (var conn = new SqlConnection())
            {
                //use the connection string in AppConfig
                conn.ConnectionString = getConnectionString();
                try
                {
                    //try to open the connection to the database
                    conn.Open();
                    //connection is a success
                    return true;
                }
                catch (Exception e)
                {
                    //connection failed
                    return false;
                }
                finally
                {
                    //the using does it but just in case
                    conn.Close();
                }
            }
        }

        public ConfigurationContext getContext()
        {
            return ConfigurationContext.Instance;
        }

        /// <summary>
        /// Return the Configuration and stores is as singleton as to not query the database each time
        /// </summary>
        /// <returns>The configuration containing all the information in the database needed for the simulation</returns>
        public Configuration getConfig()
        {
            if (CONFIGURATION != null)
                return CONFIGURATION;
            else
            { 
                using (var context = getContext())
                {
                    var roomConfig = getRoomConfiguration(context);
                    var kitchenConfig = getKitchenConfiguration(context);

                    return new Configuration(roomConfig, kitchenConfig);
                }
            }
        }

        /// <summary>
        /// Decrement the ingredients from the database entries and delete if the quantity reaches 0
        /// </summary>
        /// <param name="ingredient">The ingredient used in the recipe to be decremented</param>
        /// <param name="quantity">The quantity to use</param>
        public void consumeIngredient(IngredientType ingredient, int quantity)
        {

            using (var context = getContext())
            {
                //var result = context.StockEntries.FirstOrDefault(b => b.Ingredient == ingredient);

                var query = from b in context.StockEntries
                            where b.Ingredient == ingredient
                            orderby b.ArrivalDate
                            select b;

                var result = query.FirstOrDefault();

                int DBquantity = result.Quantity;
                if (result != null)
                {
                    if (DBquantity - quantity < 0)
                    {
                        throw new InvalidOperationException("not enough " + ingredient.ToString() + ", tyring to substract " + quantity + "from " + DBquantity);
                    }
                    else
                    {
                        if (DBquantity - quantity == 0)
                        {
                            context.StockEntries.Remove(result);
                            //remove
                        }
                        else
                        {
                            result.Quantity -= quantity;
                            context.StockEntries.AddOrUpdate(result);
                        }
                    }
                    //result.Quantity = 1;
                    //db.SaveChanges();
                    var newResult = context.Entry(result);
                    context.SaveChanges();
                }
            }

        }

        /// <summary>
        /// Create the configuration of the room or return it if it already exists
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>The configuration with all information needed to create the room</returns>
        private RoomConfiguration getRoomConfiguration(ConfigurationContext context)
        {
            if (CONFIGURATION != null)
                return ROOM_CONFIGURATION;
            else
            {
                var Personnel = getPersonnelConfiguration(context);
                var Items = getItemsConfiguration(context);
                var Tables = getTablesConfiguration(context);
                return ROOM_CONFIGURATION = new RoomConfiguration(Personnel, Items, Tables);
            }
        }

        /// <summary>
        /// Create the configuration of the kitchen or return it if it already exists
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>The configuration with all information needed to create the kitchen</returns>
        private KitchenConfiguration getKitchenConfiguration(ConfigurationContext context)
        {
            if (CONFIGURATION != null)
                return KITCHEN_CONFIGURATION;
            else
            {
                var Machines = getMachinesConfiguration(context);
                var Personnel = getPersonnelConfiguration(context);
                var Drawers = getUtensilsConfiguration(context);
                var Recipes = getRecipesConfiguration(context);
                var Stocks = getStocksConfiguration(context);
                return new KitchenConfiguration(Personnel, Drawers, Machines, Recipes, Stocks);
            }
        }

        /// <summary>
        /// Retrieve the personnel's entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the personnel in the database</returns>
        private List<PersonnelDBEntry> getPersonnelConfiguration(ConfigurationContext context)
        {
            var query = from b in context.PersonnelDBEntries
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the items' entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the items' entries in the database</returns>
        private List<ItemDBEntry> getItemsConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Items
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the tables entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the entries in the database</returns>
        private List<TableDBEntry> getTablesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Tables
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the utensils' entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the utensil's entries in the database</returns>
        private List<Drawer> getUtensilsConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Ustensils
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the recipes' steps from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the steps in the database</returns>
        private List<RecipeStep> getRecipesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Recipes
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the machines' entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the machines in the database</returns>
        private List<MachineDBEntry> getMachinesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Machines
                        select b;
            return query.ToList();
        }

        /// <summary>
        /// Retrieve the stock's entries from the database
        /// </summary>
        /// <param name="context">the updated DBContext</param>
        /// <returns>A list of all the entries in the database</returns>
        private List<StockEntry> getStocksConfiguration(ConfigurationContext context)
        {
            var query = from b in context.StockEntries
                        select b;
            return query.ToList();
        }
    }

}
