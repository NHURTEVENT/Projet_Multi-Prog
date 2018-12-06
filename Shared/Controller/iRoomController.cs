using System;
namespace Controller {
	public interface IRoomController {
		void AddClient();
		void RemoveClient(IClient client);
		void Ticked();

	}

}
