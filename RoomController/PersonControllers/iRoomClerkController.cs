using System;
namespace Controller {
	public interface IRoomClerk {
		void RefillWater(ref Model.Room.Table table);
		void RefillBread(ref Model.Room.Table table);

	}

}
