using Shared.Model;
using System;
namespace Controller {
	public interface IHeadWaiter {
		void TakeOrder(IClient client);
		void DressTable(ITable table);

	}

}
