namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class KitchenContext : DbContext
    {
        public KitchenContext()
            : base("name=KitchenContext")
        {
        }

        public DbSet<UtensilEntry> Ustensils { get; set; }
        public DbSet<MachineDBEntry> Machines { get; set; }
        //public DbSet<Drawer> Drawers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
