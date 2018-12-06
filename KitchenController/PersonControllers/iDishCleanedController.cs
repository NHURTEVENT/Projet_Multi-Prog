using System;
namespace Controller {
	public interface IDishCleanedController {
		void Clean(ref Model.Kitchen.Dish dish);
		void Help();

	}

}
