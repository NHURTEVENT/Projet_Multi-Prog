using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Model;

namespace Model
{
    public class KitchenFactory
    {
        public static IKitchenPartyChef CreatePartyChefCook(string Name)
        {
            return new PartyChef(KitchenActionFactory.CreateKitchenAction_("Cook"), Name);
        }
    }
}
