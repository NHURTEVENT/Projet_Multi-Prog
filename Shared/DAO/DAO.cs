using Shared.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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

        public void consumeIngredient(IngredientType ingredient, int quantity)
        {

            using (var context = new ConfigurationContext())
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
/*
            using (var context = new ConfigurationContext())
            {
                var entry = context.StockEntries.FirstOrDefault(e => e.Ingredient == ingredient);
                //context.Entry(entry).State = EntityState.Deleted;
                //context.DeleteOnSubmit();
                /*var adapter = (IObjectContextAdapter)context;
                var objContext = adapter.ObjectContext;
                objContext.DeleteObject(entry);
                objContext.SaveChanges();*/

                
/*                int DBquantity = entry.Quantity;
                
                
                //context.Entry(entry).State = EntityState.Deleted;
                //context.StockEntries.Remove(otherEntry);
                /*
                bool saveFailed;
                do
                {
                    saveFailed = false;

                    try
                    {
                        //context.Entry(entry).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);
                */
 /*               if (DBquantity - quantity < 0)
                {
                    throw new InvalidOperationException("not enough " + ingredient.ToString()+", tyring to substract "+quantity+"from "+DBquantity);
                }
                else
                {
                    if(DBquantity-quantity == 0)
                    {
                        context.StockEntries.Remove(entry);
                        //context.Entry(entry).State = EntityState.Deleted;
                        //context.SaveChanges();

                        //context.StockEntries.Attach(entry);
                        //context.
                        /*context.StockEntries.Remove(entry);
                        bool saveFailed;
                        do
                        {
                            saveFailed = false;

                            try
                            {
                                context.SaveChanges();
                            }
                            catch (DbUpdateConcurrencyException ex)
                            {
                                saveFailed = true;

                                // Update the values of the entity that failed to save from the store
                                ex.Entries.Single().Reload();
                            }

                        } while (saveFailed);*/
/*                    }
                    else
                    {
                        entry.Quantity = 0;
                        context.StockEntries.AddOrUpdate(entry);
                        //entry.Quantity = 1;
                        //context.SaveChanges();
                        /*bool saveFailed;
                        do
                        {
                            saveFailed = false;

                            try
                            {
                                context.SaveChanges();
                            }
                            catch (DbUpdateConcurrencyException ex)
                            {
                                saveFailed = true;

                                // Update the values of the entity that failed to save from the store
                                ex.Entries.Single().Reload();
                            }

                        } while (saveFailed);*/

  /*                  }                     
                }
            };*/
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
