using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Shared;
using Shared.Model;

namespace UnitTestDAO
{

    /// <summary>
    /// Test general connection to the database
    /// </summary>
    [TestClass]
    public class DatabaseConnectionTests
    {
        /// <summary>
        /// Seeds the database with test values
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            //Seeds the database with test entries
            //DAOSeeder.Instance.Seed();
        }

        /// <summary>
        /// Tests if the connection string is present in the appConfig so EF can use it
        /// </summary>
        [TestMethod]
        public void GivenConfigurationFileReturnsConnectionString()
        {
            Assert.IsNotNull(DAO.Instance.getConnectionString());
        }

        /// <summary>
        /// Tests if we can connect to the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseConnects()
        {
            Assert.IsTrue(DAO.Instance.connect());
        }

    }

    /// <summary>
    /// Tests in common between the Room and the Kitchen
    /// </summary>
    [TestClass]
    public class CommonTests
    {
        /// <summary>
        /// Test if the restaurant's personnel is properly retrieved from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesPersonnel()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.PersonnelDBEntries
                            where (b.PersonnelType == PersonnelType.WAITER)
                            select b;
                var type = query.FirstOrDefault().Quantity;
                Assert.AreEqual(query.FirstOrDefault().Quantity, 4);
            }
        }

        /// <summary>
        /// Test if the restaurant's configuration is properly created
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetievesConfiguration()
        {
            Assert.IsNotNull(DAO.Instance.getConfig());
        }

    }
    
    /// <summary>
    /// Tests of general CRUD to the database
    /// </summary>
    [TestClass]
    public class CRUDTests
    {
        /// <summary>
        /// Test if data is properly retrieved from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesData()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Ustensils
                            orderby b.UtensilType
                            where b.UtensilType == UtensilType.FORK
                            select b;
                var name = query.FirstOrDefault().UtensilType;
                //We know these values from our test dataset
                Assert.AreEqual(query.FirstOrDefault().Quantity, 10);
            }
        }

        /// <summary>
        /// Test if stock is properly updated
        /// </summary>
        [TestMethod]
        public void GivenIngredientAndQuantityDecrementsStock()
        {
            //create a new entry in case there's none
            var dt = DateTime.Now;
            var entry = new StockEntry(IngredientType.PASTA, 2, new DateTime(dt.AddDays(-7).Ticks - dt.AddDays(-7).Ticks % TimeSpan.TicksPerMinute));
            //value used for latter comparaison
            int beforeDecrement;
            using (var context = DAO.Instance.getContext())
            {
                //add the entry to the database
                context.StockEntries.AddOrUpdate(entry);
                context.SaveChanges();

                //get entries and sort by arrival date
                var query = from b in context.StockEntries
                            where b.Ingredient == IngredientType.PASTA
                            orderby b.ArrivalDate
                            select b;
                //get oldest entry
                entry = query.FirstOrDefault();
                //test if the entry is there
                Assert.IsNotNull(entry);
                //get the value before we decrement it
                beforeDecrement = entry.Quantity;
                //consume the ingredient
                DAO.Instance.consumeIngredient(IngredientType.PASTA, 1);
                //update the context
                var Objcontext = ((IObjectContextAdapter)context).ObjectContext;
                Objcontext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, context.StockEntries);
            }
            //Update of the context odly doesn't work here so we have to close the connection and reopen it
            //due to this issue the test has to be repetitive instead of just beeing the code seen below
            using (var context = DAO.Instance.getContext())
            {
                //get the updated entry
                var result = context.StockEntries.Find(entry.Ingredient, entry.ArrivalDate);
                
                /** if the ingredient only had one left on the oldest entry ot's been deleted
                * we won't be able to test if the value was decremented
                * so we try again until we find one with more than one left.
                * Worst case scenario it will be the one we added
                */
                while (result == null)
                {
                    var query2 = from b in context.StockEntries
                                 where b.Ingredient == IngredientType.PASTA
                                 orderby b.ArrivalDate
                                 select b;
                    //get oldest entry
                    result = query2.FirstOrDefault();
                    //get the quantity before we decrement it
                    beforeDecrement = result.Quantity;
                    //consume the ingredient
                    DAO.Instance.consumeIngredient(IngredientType.PASTA, 1);
                    //update the context
                    /** due to some issue the context doesn't update everytime after an insertion 
                    so we can't just use the code of this second using as our test although it's a duplicate of the foirst usign
                    the only difference being we don't add an entry, just update it
                    */
                    var Objcontext = ((IObjectContextAdapter)context).ObjectContext;
                    Objcontext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, context.StockEntries);
                    //get oldest entry
                    result = context.StockEntries.Find(result.Ingredient, result.ArrivalDate);
                }

                //check if it's been decremented
                Assert.AreEqual(beforeDecrement - 1, result.Quantity);
            }

        }

        /// <summary>
        /// Test if a stock entry is deleted when the quantity reaches 0
        /// </summary>
        [TestMethod]
        public void GivenStockDeleteEmptyStockEntry()
        {
            //create a new entry that we will delete
            var dt = DateTime.Now;
            var entry = new StockEntry(IngredientType.CARROT, 1, new DateTime(dt.AddDays(-7).Ticks - dt.AddDays(-7).Ticks % TimeSpan.TicksPerSecond));

            using (var context = DAO.Instance.getContext())
            {
                //add it to the database
                context.StockEntries.Add(entry);
                context.SaveChanges();

                //get entries and sort by arrival date
                var query = from b in context.StockEntries
                            where b.Ingredient == IngredientType.CARROT
                            orderby b.ArrivalDate
                            select b;
                //get oldest entry
                entry = query.FirstOrDefault();
                //show the entry is there
                Assert.IsNotNull(entry);
                //get the value before we decrement it, since the quantity is 1 it will be deleted
                int beforeDecrement = entry.Quantity;
                //consume the ingredient
                DAO.Instance.consumeIngredient(IngredientType.CARROT, 1);
                //update the context
                var Objcontext = ((IObjectContextAdapter)context).ObjectContext;
                Objcontext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, context.StockEntries);
            }
            /**
            * Same issue as with the update test, the context doesn't always update 
            */
            using (var context = DAO.Instance.getContext())
            {
                //get the updated entry
                var result = context.StockEntries.Find(entry.Ingredient, entry.ArrivalDate);
                //check if it's been decremented
                Assert.IsNull(result);
            }
        }

    }

    /// <summary>
    /// Tests specific to the creation of the room's configuration information
    /// </summary>
    [TestClass]
    public class RoomConfigTests
    {
        /// <summary>
        /// Test if the tables are properly retrived from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesTables()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Tables
                            where (b.Square == 1) && (b.Row == 1) && (b.Column == 1)
                            select b;
                var type = query.FirstOrDefault().Size;
                Assert.AreEqual(query.FirstOrDefault().Size, 2);
            }
        }

        /// <summary>
        /// Test if the items (napkins, cups, cutlery, etc) are properly retrieved from the database 
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesItems()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Items
                            where (b.ItemType == ItemType.FLAT_PLATES)
                            select b;
                var quantity = query.FirstOrDefault().Quantity;
                Assert.AreEqual(quantity, 30);
            }
        }

    }

    /// <summary>
    /// Tests specific to the creation of the kitchen's configuration information
    /// </summary>
    [TestClass]
    public class KitchenConfigClass
    {
        /// <summary>
        /// Test if the utensils are properly retrived from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesUtensils()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Ustensils
                            where b.UtensilType == UtensilType.FORK
                            select b;
                Assert.AreEqual(query.FirstOrDefault().Quantity, 10);
            }
        }

        /// <summary>
        /// Test if the machines are properly retrived from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesMachines()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Machines
                            where b.MachineId == 1
                            select b;
                var type = query.FirstOrDefault().MachineType;
                Assert.AreEqual(MachineType.WASHING, type);
            }
        }

        /// <summary>
        /// Test if the recipes are properly retrived from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesRecipe()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.Recipes
                            where (b.Dish == Dish.FRENCHFRIES) && (b.Step == 1)
                            select b;
                var name = query.FirstOrDefault().Name;
                Assert.IsTrue(String.Equals(name, "cut the potatoes"));
            }
        }

        /// <summary>
        /// Test if the stock is properly retrived from the database
        /// </summary>
        [TestMethod]
        public void GivenDatabaseRetrievesStock()
        {
            using (var context = DAO.Instance.getContext())
            {
                var query = from b in context.StockEntries
                            where (b.Ingredient == IngredientType.POTATO)
                            select b;
                var quantity = query.FirstOrDefault().Quantity;
                Assert.AreEqual(quantity, 100);
            }
        }
    }
}

