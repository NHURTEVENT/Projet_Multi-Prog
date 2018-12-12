using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IKitchenChef : IPerson, IObserver<string>
    {
        List<Dish> DishOrder { get; set; }
        List<IAction> KActionQueue { get; set; }

        void TakeDishInCharge(IDish dish);
        void TakeDishOrder(IKitchenPartyChef PartyChef);
    }
}
