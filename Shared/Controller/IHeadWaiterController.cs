using System;

namespace Shared {
	public interface IHeadWaiterController {
		void TakeOrder(IClient client);
		void DressTable(ITable table);

	}

}
