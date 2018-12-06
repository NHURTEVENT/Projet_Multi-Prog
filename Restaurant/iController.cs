using System;
namespace Controller {
	public interface IController {
		Model.IRestaurant GetRestaurant();
		IRoomController GetRoomController();
		IKitchenController GetKitchenController();
		void Ticked();

	}

}
