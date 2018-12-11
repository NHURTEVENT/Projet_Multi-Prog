using System;

namespace Shared {
	public interface IRoomClerkController
    {
		void RefillWater(ITable table);
		void RefillBread(ITable table);

	}

}
