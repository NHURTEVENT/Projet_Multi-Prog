using System;

namespace Shared {
	public interface IRoomController {
		void AddClient();
		void RemoveClient(IClient client);
		void Ticked();

	}

}
