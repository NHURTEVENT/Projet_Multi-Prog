using Shared.Model;
using System;
namespace Controller {
	public interface IRoomClerkController {
		void RefillWater(ITable table);
		void RefillBread(ITable table);

	}

}
