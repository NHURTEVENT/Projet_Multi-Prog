using System;

namespace Shared {
	public interface IKitchenClerkController {
		void Prepare(IRecipe recipe);

        void takeOrder(IKitchenChefController kitchenChefController);
        void bringDish(IDish dish);

	}

}
