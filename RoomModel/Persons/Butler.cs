using Shared;
using System;

namespace Model {
	public interface Butler : IPerson {
		void Redirect(IClient client);

	}

}
