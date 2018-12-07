using Shared.Model;
using System;
namespace Controller {
	public interface IHeadWaiterController {
		void TakeOrder(IClient client);
		void DressTable(ITable table);

	}

}
