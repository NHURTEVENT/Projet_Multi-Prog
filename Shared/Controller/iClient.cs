using System;
using System.Collections.Generic;

namespace Controller {
	public interface IClient {
		void Book();
		List<Dish> GetOrder();
		void ConsumeWaterAndBread();
		void Pay();

	}

}
