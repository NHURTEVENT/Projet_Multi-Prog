using System;
namespace Controller {
	public interface IHeadWaiter {
		void TakeOrder(ref object client_Client);
		void DressTable(ref object table_Table);

	}

}
