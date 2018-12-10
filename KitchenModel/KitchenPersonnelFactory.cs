using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class KitchenPersonnelFactory
    {

        public static IKitchenChef CreateKitchenPChef(List<IDish> dish, List<IKitchenChef> kitchenchef)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_("Prepare"), Name);
        }

       /* public static IKitchenPartyChef CreateDish(string Name)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_(), Name);
        }*/

        public static IDishCleaner CreateWash(string Name)
        {
            return new DishCleaner(KitchenActionFactory.CreateKitchenAction_("Wash"), Name);
        }

        public static IKitchenChef CreateOrderDish(string Name)
        {
            return new KitchenChef(KitchenActionFactory.CreateKitchenAction_("ToOrder"), Name);
        }
    }
        public static IKitchenClerk CreateBring(string Name)
        {
            return new KitchenClerk(KitchenActionFactory.CreateKitchenAction_("Bring"), Name);
        }
    }
}