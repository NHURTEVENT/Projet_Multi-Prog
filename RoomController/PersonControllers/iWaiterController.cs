using System;
namespace Controller {
	public interface IWaiter {
		void CleanTable();
		void GiveOrder(ref object client_iClient);
		void FetchOrder(ref List<Model.Kitchen.Dish> order);

	}

}
