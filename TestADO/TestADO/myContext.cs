using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestADO
{
    class myContext : DbContext
    {
        /*public DbSet<Cupboard> Cupboards { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Ustensil> Ustensils  { get; set; }
        public DbSet<Butler> Butlers { get; set; }
        public DbSet<HeadWaiter> HeadWaiters { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Table> Tables { get; set; }*/
        public DbSet<Ustensil> Ustensils { get; set; }
        public DbSet<Table> Tables { get; set; }

        //public DbSet<Dish> Dishes;


        public myContext() : base("myContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
