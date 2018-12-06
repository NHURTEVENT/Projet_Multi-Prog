using System;
using System.Drawing;

namespace Model {
	public interface IPerson {
		Point GetPosition();
		void Move(Point position);
		String getCurrentAction();
        void setTask(String task);
        int getRemainingTicks();
        void setRemainingTicks(int tick);
        //PersonType getType();

    }

}
