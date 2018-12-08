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
            var ustensils = new List<UtensilEntry>
            {/*
                new UtensilEntry("fork",10),
                new UtensilEntry("spork",20),
                new UtensilEntry("knife",30)*/
            };
            ustensils.ForEach(u => context.Ustensils.Add(u));

            context.SaveChanges();

            var machines = new List<MachineDBEntry>
            {/*
                new MachineDBEntry("washing",10,1,30,1,3),
                new MachineDBEntry("washing",30,1,60,1,3)*/
            };
            machines.ForEach(m => context.Machines.Add(m));
            context.SaveChanges();
        }
    }
}
