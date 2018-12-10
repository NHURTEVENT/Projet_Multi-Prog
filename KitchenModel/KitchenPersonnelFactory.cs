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

        public static IKitchenPartyChef CreateDish(string Name)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_(), Name);
        }

    }
}