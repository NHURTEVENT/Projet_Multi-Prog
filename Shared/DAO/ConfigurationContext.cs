namespace Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /**
     * Contains all the all relevant information about the restaurant stored in the database
     **/
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
            : base("name=ConfigurationContext")
        {
        }
        //Entries of all relevant information about the restaurant stored in the database
        //They will be used to generate their corresponding objects with factories
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
