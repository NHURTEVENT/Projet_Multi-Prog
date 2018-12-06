using System;
namespace Controller {
	public interface IKitchenChefController {
		void Cook(ref Model.Kitchen.Dish dish);
		void RequestUstensil(ref Model.Kitchen.Ustensil ustensil);
		void FreeUstensil(ref Model.Kitchen.Ustensil ustensil);
		void ManageClerk();

	}

}
