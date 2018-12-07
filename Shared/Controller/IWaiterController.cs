using System;
using System.Collections.Generic;

namespace Shared {
	public interface IWaiterController {

		void CleanTable();
		void GiveOrder(IClient client);
		void FetchOrder(ref List<Dish> order);

	}

}
