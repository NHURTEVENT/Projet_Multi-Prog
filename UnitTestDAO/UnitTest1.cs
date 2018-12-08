using System;
using System.Linq;
using KitchenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

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
                            orderby b.Utensil
                            select b;
                var name = query.FirstOrDefault().Utensil;
                Assert.IsTrue(String.Equals("fork",query.FirstOrDefault().Utensil));
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
                            where b.Utensil == "fork"
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
        
    }
}
