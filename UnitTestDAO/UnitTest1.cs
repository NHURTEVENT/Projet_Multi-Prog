﻿using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Shared;
using Shared.Model;

namespace UnitTestDAO
{
    [TestClass]
    public class UnitTest1
    {
    
       //Generic
        [TestMethod]
        public void GivenConfigurationFileReturnsConnectionString()
        {
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                Assert.IsNotNull(modelDAOInitializer.getConnectionString());
            }

        }

        [TestMethod]
        public void GivenDatabaseConnects()
        {
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                Assert.IsNotNull(modelDAOInitializer.getConnectionString());
            }
        }


        [TestMethod]
        public void GivenDatabaseRetrievesData()
        {
            using (var context = new ConfigurationContext())
            {
                //ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                //DAOSeeder DAOSeeder = new DAOSeeder(context);
                var query = from b in context.Ustensils
                            orderby b.UtensilType
                            where b.UtensilType == UtensilType.FORK
                            select b;
                var name = query.FirstOrDefault().UtensilType;
                Assert.AreEqual(query.FirstOrDefault().Quantity,10);
            }
        }

        
        //Kitchen
        [TestMethod]
        public void GivenDatabaseRetrievesUtensils()
        {
            using (var context = new ConfigurationContext())
            {
                //ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                var query = from b in context.Ustensils
                            where b.UtensilType == UtensilType.FORK
                            select b;

                Assert.AreEqual(query.FirstOrDefault().Quantity,10);
            }
        }

        [TestMethod]
        public void GivenDatabaseRetrievesMachines()
        {
            using (var context = new ConfigurationContext())
            {
                //ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                var query = from b in context.Machines
                            where b.MachineId == 1
                            select b;
                var type = query.FirstOrDefault().MachineType;
                Assert.IsTrue(String.Equals(query.FirstOrDefault().MachineType, "washing"));
            }
        }

        [TestMethod]
        public void GivenDatabaseRetrievesRecipe()
        {
            using (var context = new ConfigurationContext())
            {
                //ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                DAOSeeder DAOSeeder = new DAOSeeder(context);
                var query = from b in context.Recipes
                            where (b.Dish == Dish.FRENCHFRIES) &&( b.Step == 1 ) 
                            select b;
                var type = query.FirstOrDefault().Name;
                Assert.IsTrue(String.Equals(query.FirstOrDefault().Name, "cut potatoes"));
            }
        }
       

        //Room
        [TestMethod]
        public void GivenDatabaseRetrievesTables()
        {
            using (var context = new ConfigurationContext())
            {
                //DAOSeeder DAOSeeder = new DAOSeeder(context);
                //Assert.IsNotNull(DAOSeeder.getConnectionString());
                var query = from b in context.Tables
                            where (b.Square == 1) && (b.Row == 1) && (b.Column == 1)
                            select b;
                var type = query.FirstOrDefault().Size;
                Assert.AreEqual(query.FirstOrDefault().Size, 2);
            }
        }

        [TestMethod]
        public void GivenDatabaseRetrievesItems()
        {
            using (var context = new ConfigurationContext())
            {
                //DAOSeeder DAOSeeder = new DAOSeeder(context);
                //Assert.IsNotNull(DAOSeeder.getConnectionString());
                var query = from b in context.Items
                            where (b.ItemType == ItemType.FLAT_PLATES)
                            select b;
                var type = query.FirstOrDefault().Quantity;
                Assert.AreEqual(query.FirstOrDefault().Quantity, 30);
            }
        }


        [TestMethod]
        public void GivenDatabaseRetrievesPersonnel()
        {
            using (var context = new ConfigurationContext())
            {
                //DAOSeeder DAOSeeder = new DAOSeeder(context);
                //Assert.IsNotNull(DAOSeeder.getConnectionString());
                var query = from b in context.PersonnelDBEntries
                            where (b.PersonnelType == PersonnelType.WAITER)
                            select b;
                var type = query.FirstOrDefault().Quantity;
                Assert.AreEqual(query.FirstOrDefault().Quantity, 4);
            }
        }

        [TestMethod]
        public void GivenDatabaseRetievesConfiguration()
        {
            Assert.IsNotNull(DAO.Instance.getConfig());
        }

        [TestMethod]
        public void GivenDatabaseRetrievesStock()
        {
            using (var context = new ConfigurationContext())
            {
                //DAOSeeder DAOSeeder = new DAOSeeder(context);
                //Assert.IsNotNull(DAOSeeder.getConnectionString());
                var query = from b in context.StockEntries
                            where (b.Ingredient == IngredientType.POTATO)
                            select b;
                var type = query.FirstOrDefault().Quantity;
                Assert.AreEqual(query.FirstOrDefault().Quantity, 100);
            }
        }

        [TestMethod]
        public void GivenIngredientAndQuantityDecrementsStock()
        {
           
            using (var context = new ConfigurationContext())
            {
                //create a new entry in case there's none
                var dt = DateTime.Now;
                var entry = new StockEntry(IngredientType.PASTA, 25, new DateTime(dt.AddDays(-7).Ticks - dt.AddDays(-7).Ticks % TimeSpan.TicksPerSecond));

                //add it to the database
                context.StockEntries.Add(entry);
                context.SaveChanges();

                //get entries and sort by arrival date
                var query = from b in context.StockEntries
                            where b.Ingredient == IngredientType.PASTA
                            orderby b.ArrivalDate
                            select b;
                //get oldest entry
                entry = query.FirstOrDefault();
                //show the entry is there
                Assert.IsNotNull(entry);
                //get the value before we decrement it
                int beforeDecrement = entry.Quantity;
                DAO.Instance.consumeIngredient(IngredientType.PASTA, 1);
                var Objcontext = ((IObjectContextAdapter)context).ObjectContext;
                Objcontext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, context.StockEntries);
                var result = context.StockEntries.Find(entry.Ingredient, entry.ArrivalDate).Quantity;
                Assert.AreEqual(beforeDecrement - 1, result);
            }
           
        }

        [TestMethod]
        public void GivenStockUpdatesStock()
        {
            
           /* using (var db = new ConfigurationContext())
            {
                var result = db.StockEntries.FirstOrDefault(b => b.Ingredient == IngredientType.PASTA);
                
                result.Quantity = 0;
                if (result != null)
                {
                    //result.Quantity = 1;
                    //db.SaveChanges();
                    db.StockEntries.AddOrUpdate(result);
                    db.SaveChanges();
                }
            }*/
/*
            var dt = DateTime.Now;
            var entry = new StockEntry(IngredientType.PASTA, 2, new DateTime(dt.AddDays(-7).Ticks - dt.AddDays(-7).Ticks % TimeSpan.TicksPerSecond));
            using (var context = new ConfigurationContext())
            {

                context.StockEntries.Add(entry);
                context.SaveChanges();

                Assert.IsNotNull(context.StockEntries.Find(entry.Ingredient, entry.ArrivalDate));

                DAO.Instance.consumeIngredient(IngredientType.PASTA, 2);

            }
            using (var context = new ConfigurationContext()) { 

                var result = context.StockEntries.Find(entry.Ingredient, entry.ArrivalDate);
                Assert.IsNull(result);
            }
            
*/
            /*var query = from i in context.StockEntries
                        select i;*/


        }

       
    }
}
