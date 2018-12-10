using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class KitchenActionFactory
    {

        public static IAction CreateKitchenAction_(string Name = "wait")
        {
            switch (Name)
            {
                //préparer
                case "Prepare":
                    return new KitchenAction_("Prepare", 1);
                
                //eplucher
                case "Peel":
                    return new KitchenAction_("Peel", 1);

                // Laver
                case "Wash":
                    return new KitchenAction_("Wash", 2);

                // ordonner     
                case "ToOder":
                    return new KitchenAction_("ToOrder", 1);

                //apporter
                case "Bring":
                    return new KitchenAction_("Bring", 1);

                //Machine a laver lave
                case "DishWasher":
                    return new KitchenAction_("DishWasher", 10);

                // Lave linge lave
                case "WashingMachine":
                    return new KitchenAction_("WashingMachine", 15);

                //recuperer
                case "recover":
                    return new KitchenAction_("recover", 1);

                default:
                    return new KitchenAction_("Wait", 1);


            }
        }

    }
}