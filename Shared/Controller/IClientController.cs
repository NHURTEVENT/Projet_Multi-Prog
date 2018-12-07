using System;
using System.Collections.Generic;

namespace Shared {

	public interface IClientController {
		void Book();
		List<Dish> GetOrder();
		void ConsumeWaterAndBread();
		void Pay();

	}

}
