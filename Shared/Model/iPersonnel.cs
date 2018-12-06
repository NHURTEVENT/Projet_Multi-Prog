using System;
using System.Drawing;

namespace Model {
	public interface IPersonnel {
		Point GetPosition();
		void Move(Point position);
		IAction GetAction();

	}

}
