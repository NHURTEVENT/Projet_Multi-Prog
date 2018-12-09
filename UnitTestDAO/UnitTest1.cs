using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Shared;

namespace UnitTestDAO
{
    [TestClass]
    public class UnitTest1
    {
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
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                var query = from b in context.Ustensils
                            orderby b.UtensilType
                            select b;
                var name = query.FirstOrDefault().UtensilType;
                Assert.IsTrue(String.Equals(UtensilType.FORK,query.FirstOrDefault().UtensilType));
            }
        }

        [TestMethod]
        public void GivenDatabaseRetrievesUtensils()
        {
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
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
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
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
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
                //Assert.IsNotNull(modelDAOInitializer.getConnectionString());
                var query = from b in context.Recipes
                            where (b.Dish == Dish.FRENCHFRIES) &&( b.Step == 1 ) 
                            select b;
                var type = query.FirstOrDefault().Name;
                Assert.IsTrue(String.Equals(query.FirstOrDefault().Name, "cut the popatoes"));
            }
        }
        
    }
}
