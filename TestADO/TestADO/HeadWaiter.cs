using System;
using System.Drawing;

public class HeadWaiter : RoomPersonnel  {
	public Point GetPosition() {
		throw new System.Exception("Not implemented");
	}
	public void Move(ref Point position) {
		throw new System.Exception("Not implemented");
	}
	public Room GetRoom() {
		throw new System.Exception("Not implemented");
	}

	private RoomClerk[] roomClerks;


}
