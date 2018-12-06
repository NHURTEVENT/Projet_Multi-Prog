using Shared.Model;
using System;
namespace Controller {
	public interface Butler : IButler {
		void Redirect(IClient client);

	}

}
