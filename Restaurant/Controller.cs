using System;
namespace Controller {
	public class Controller : IController  {
		public void Ticked() {
			throw new System.Exception("Not implemented");
		}
		public IKitchenController GetKitchenController() {
			throw new System.Exception("Not implemented");
		}
		public IRoomController GetRoomController() {
			throw new System.Exception("Not implemented");
		}
		public Model.IRestaurant GetRestaurant() {
			throw new System.Exception("Not implemented");
		}

		private IKitchenController kitchenController;
		private IRoomController roomController;

	}

}
