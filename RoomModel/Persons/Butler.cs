using System;
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

	private HeadWaiter[] headwaiters;

}
