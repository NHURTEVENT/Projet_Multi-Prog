using System;
namespace Model {
	public interface IAction {
		void Act();
        int getRemainingTicks();
        void release();
	}

}
