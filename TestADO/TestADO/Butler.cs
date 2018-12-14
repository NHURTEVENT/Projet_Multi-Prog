using System;
using System.Drawing;
public class Butler : RoomPersonnel  {
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public Room GetRoom() {
		throw new System.Exception("Not implemented");
	}

    Point IPersonnel.GetPosition()
    {
        throw new NotImplementedException();
    }

    private HeadWaiter[] headwaiters;

}
