using System;
namespace Shared {

	public interface IKitchenChefController {
		void Cook(Dish dish);
		void RequestUstensil(IUtensil ustensil);
		void FreeUstensil(IUtensil ustensil);
		void ManageClerk();

	}

}
