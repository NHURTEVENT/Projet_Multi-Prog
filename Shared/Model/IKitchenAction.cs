using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class KitchenActionFactory
    {

        public static IAction CreateKitchenAction_(string Name = "Kitchen")
        {
            switch (Name)
            {
                case "Prepare":
                    return new KitchenAction_("Prepare", 1);

                case "Peel":
                    return new KitchenAction_("Peel", 1);

                case "BigWash":
                    return new KitchenAction_("BigWash", 2);


            }
        }

    }
}