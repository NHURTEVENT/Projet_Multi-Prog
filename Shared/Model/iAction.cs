using System;

namespace Shared {
	public interface IAction {
		void Act();
        int getRemainingTicks();
        void release();
	}

}
