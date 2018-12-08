namespace KitchenModel
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

        public DbSet<Ustensil> Ustensils { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
