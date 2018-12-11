using Shared.Model;
using System;
using System.Collections.Generic;
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


        public Configuration getConfig()
        {
            if (CONFIGURATION != null)
                return CONFIGURATION;
            else
            { 
                using (var context = new ConfigurationContext())
                {
                    var roomConfig = getRoomConfiguration(context);
                    var kitchenConfig = getKitchenConfiguration(context);

                    return new Configuration(roomConfig, kitchenConfig);
                }
            }
        }

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

        private List<PersonnelDBEntry> getPersonnelConfiguration(ConfigurationContext context)
        {
            var query = from b in context.PersonnelDBEntries
                        select b;
            return query.ToList();
        }

        private List<ItemDBEntry> getItemsConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Items
                        select b;
            return query.ToList();
        }

        private List<TableDBEntry> getTablesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Tables
                        select b;
            return query.ToList();
        }

        private List<Drawer> getUtensilsConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Ustensils
                        select b;
            return query.ToList();
        }

        private List<RecipeStep> getRecipesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Recipes
                        select b;
            return query.ToList();
        }

        private List<MachineDBEntry> getMachinesConfiguration(ConfigurationContext context)
        {
            var query = from b in context.Machines
                        select b;
            return query.ToList();
        }

        private List<StockEntry> getStocksConfiguration(ConfigurationContext context)
        {
            var query = from b in context.StockEntries
                        select b;
            return query.ToList();
        }
    }

}
