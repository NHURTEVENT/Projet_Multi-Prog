using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace KitchenModel
{
    public class KitchenContext : DbContext
    {
        public DbSet<Ustensil> Ustensils { get; set; }
        //public DbSet<Table> Tables { get; set; }

        //public DbSet<Dish> Dishes;


        public KitchenContext() : base("myContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
