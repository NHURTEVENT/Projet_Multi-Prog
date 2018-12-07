using KitchenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new KitchenContext())
            {
                ModelDAOInitializer modelDAOInitializer = new ModelDAOInitializer(context);
            }
            Restaurant r = new Restaurant();

        }
    }
}
