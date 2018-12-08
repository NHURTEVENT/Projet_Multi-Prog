using System;
using System.Linq;
using KitchenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                            orderby b.Name
                            select b;
                var name = query.FirstOrDefault().Name;
                Assert.IsTrue(String.Equals("pan",query.FirstOrDefault().Name));
            }
        }
        
    }
}
