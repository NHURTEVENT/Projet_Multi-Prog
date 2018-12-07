using System;
using System.Drawing;

namespace Shared {
	public interface IPerson {

		Point GetPosition();
		void Move(Point position);
        void setTask(String task);
        //PersonType getType();

        int remainingTicks { get; set; }
        string currentAction { get; set; }
        
    }

}
