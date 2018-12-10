using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    public static class KitchenPersonnelFactory
    {

        public static IKitchenPartyChef CreatePrepareDish(string Name)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_("Prepare"), Name);
        }

       /* public static IKitchenPartyChef CreateDish(string Name)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_(), Name);
        }*/

        public static DishCleaner CreateWash(string Name)
        {
            return new DishCleaner(KitchenActionFactory.CreateKitchenAction_("Wash"), Name);
        }

        public static KitchenChef CreateOrderDish(string Name)
        {
            return new KitchenChef(KitchenActionFactory.CreateKitchenAction_("ToOrder"), Name);
        }
    }
        public static KitchenClerk CreateBring(string Name)
        {
            return new KitchenClerk(KitchenActionFactory.CreateKitchenAction_("Bring"), Name);
        }
    }
}