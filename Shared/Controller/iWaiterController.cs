using Shared.Model;
using System;
using System.Collections.Generic;

namespace Controller {
	public interface IWaiterController {
		void CleanTable();
		void GiveOrder(IClient client);
		void FetchOrder(ref List<Dish> order);

	}

}
