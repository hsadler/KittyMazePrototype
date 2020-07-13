using System.Collections;
using System.Collections.Generic;

public class MazeWall {

	// MODEL FOR MAZE WALL


	public bool isOpen = false;
	public bool isOutwall = false;


	public MazeWall(bool isOpen, bool isOutwall) {
		this.isOpen = isOpen;
		this.isOutwall = isOutwall;
	}
	

}
