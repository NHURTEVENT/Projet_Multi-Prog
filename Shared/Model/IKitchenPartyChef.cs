using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IKitchenPartyChef : IPerson, IObserver<string>
    {
        List<Dish> DishOrder { get; set; }
        List<IAction> KActionQueue { get; set; }
        
        List<IRecipe> RecipeOrder { get; set; }

        void cook(IDish dish);

    }
}
