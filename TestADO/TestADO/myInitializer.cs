using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace TestADO
{
    class myInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<myContext>
    {

        public myInitializer(myContext context)
        {
            Seed(context);
        }

        protected override void Seed(myContext context)
        {/*
            var ustensils = new List<Ustensil>
            {
                new Ustensil("spork", Dish.NONE),
                new Ustensil("pan", Dish.CHICKEN)
            };
            ustensils.ForEach(s => context.Ustensils.Add(s));


            var tables = new List<Table>
            {
                new Table(2,1,1,1),
                new Table(2,2,1,1),
                new Table(8,3,1,1)
            };
            tables.ForEach(t => context.Tables.Add(t));

            context.SaveChanges();*/
            var ustensils = new List<Ustensil>
            {
                new Ustensil("spork",Dish.NONE),
                new Ustensil("pan", Dish.CHICKEN)
            };
            ustensils.ForEach(s => context.Ustensils.Add(s));




            context.SaveChanges();

        }
    }
}
