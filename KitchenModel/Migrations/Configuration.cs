namespace Model
{
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KitchenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Model.KitchenContext";
        }

        protected override void Seed(KitchenContext context)
        {
            //  This method will be called after migrating to the latest version.
            //passer par la factory pour l'ustensil
            //var Recipes= new List<RecipeStep>{ new RecipeStep(Dish.FRENCHFRIES,1, )};
            //Recipes.ForEach(r => context.Recipes.Add(r));
            //context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
