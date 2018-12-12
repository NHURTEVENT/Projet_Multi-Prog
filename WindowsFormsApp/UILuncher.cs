using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class UILuncher
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormView());
        }
        // todo: implement
        
        /*
            public UILuncher()
        {
            new FormView();
        }*/

        public class ViewRoom
        {
            public void GetRoom()
            {
                throw new System.Exception("Not implemented");
            }
            public void UpdatePeople()
            {
                throw new System.Exception("Not implemented");
            }
            public void UpdateTable()
            {
                throw new System.Exception("Not implemented");
            }


        }

        public class ViewKitchen
        {
            public void onTick()
            {
               
            }
            public void GetKitchen()
            {
                throw new System.Exception("Not implemented");
            }
            public void UpdatePeople()
            {
                throw new System.Exception("Not implemented");
            }
            public void UpdateMachines()
            {

            }

        }
    }
}
