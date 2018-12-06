using System;
using System.Collections.Generic;

namespace Controller {
	public interface IClientController {
		void Book();
		List<Dish> GetOrder();
		void ConsumeWaterAndBread();
		void Pay();

	}

}
