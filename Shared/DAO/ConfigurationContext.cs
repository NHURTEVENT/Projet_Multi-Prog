namespace Shared
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
            : base("name=ConfigurationContext")
        {
        }

        public DbSet<TableDBEntry> Tables { get; set; }
        public DbSet<PersonnelDBEntry> PersonnelDBEntries { get; set; }
        public DbSet<ItemDBEntry> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
