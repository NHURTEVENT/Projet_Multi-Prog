using Shared.Model;
using System;
namespace Controller {
	public interface IController {
		IRestaurant GetRestaurant();
		IRoomController GetRoomController();
		IKitchenController GetKitchenController();
		void Ticked();

	}

}
