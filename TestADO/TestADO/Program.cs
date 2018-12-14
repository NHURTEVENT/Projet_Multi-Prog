using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace TestADO
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
            using (var db = new myContext())
            {
                myInitializer init = new myInitializer(db);
                Console.WriteLine("hello");
                //var name = Console.ReadLine();
                //var ust = new Ustensil(name, Dish.CHICKEN);
            }
            //Application.Run(new Form1());
        }
    }
}
