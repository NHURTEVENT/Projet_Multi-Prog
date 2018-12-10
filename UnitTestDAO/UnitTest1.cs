using System;
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
    }
}
