using Shared.Model;
using System;
namespace Controller {
	public interface IRoomClerk {
		void RefillWater(ITable table);
		void RefillBread(ITable table);

	}

}
