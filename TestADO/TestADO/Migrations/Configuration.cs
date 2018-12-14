namespace TestADO.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestADO.myContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TestADO.myContext";
        }

        protected override void Seed(TestADO.myContext context)
        {
            //  This method will be called after migrating to the latest version.
            var ustensils = new List<Ustensil>
            {
                new Ustensil("spork", Dish.NONE),
                new Ustensil("pan", Dish.CHICKEN)
            };
            ustensils.ForEach(s => context.Ustensils.Add(s));
            context.SaveChanges();

            var tables = new List<Table>
            {
                new Table(2,1,1,1),
                new Table(2,2,1,1),
                new Table(8,3,1,1)
            };
            tables.ForEach(t => context.Tables.Add(t));

            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
