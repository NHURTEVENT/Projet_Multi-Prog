namespace Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
            : base("name=ConfigurationContext")
        {
        }

        public DbSet<TableDBEntry> Tables { get; set; }
        public DbSet<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        public DbSet<ItemDBEntry> Items { get; set; }
        public DbSet<Drawer> Ustensils { get; set; }
        public DbSet<MachineDBEntry> Machines { get; set; }
        public DbSet<RecipeStep> Recipes { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
