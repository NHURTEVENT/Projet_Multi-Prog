using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Shared;
using Model;
using System.Data.SqlClient;

namespace KitchenModel
{
    public class ModelDAOInitializer : DropCreateDatabaseIfModelChanges<KitchenContext>
    {
        public ModelDAOInitializer(KitchenContext context)
        {
            Seed(context);
        }

        public string getConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["KitchenContext"].ConnectionString.ToString();
        }

        public SqlConnection connect()
        {
            return new SqlConnection();
        }

        protected override void Seed(KitchenContext context)
        {
            var ustensils = new List<Ustensil>
            {
                new Ustensil(Dish.NONE, "spork"),
                new Ustensil(Dish.CHICKEN, "pan")
            };
            ustensils.ForEach(s => context.Ustensils.Add(s));

            context.SaveChanges();
        }
    }
}
