using System;

namespace Shared {
	public interface IHeadWaiter {
		void TakeOrder(IClient client);
		void DressTable(ITable table);

	}

}
