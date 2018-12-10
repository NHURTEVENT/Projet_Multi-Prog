using System;
namespace Shared {

	public interface IKitchenChefController {
		void Cook(Dish dish);
		void RequestUstensil(IUstensil ustensil);
		void FreeUstensil(IUstensil ustensil);
		void ManageClerk();

        void takeOrder(IHeadKitchenChefController headKitchenChef);
        void giveOrder(IKitchenClerkController kitchenClerk);

	}

}
