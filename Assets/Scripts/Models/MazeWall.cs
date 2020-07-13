using System.Collections;
using System.Collections.Generic;

public class MazeWall {

	// MODEL FOR MAZE WALL


	public float position_X;
	public float position_Y;

	public bool isOpen = false;
	public bool isOutwall = false;
	public bool isHorizontal = false;


	public MazeWall(
		float position_X, 
		float position_Y, 
		bool isOpen, 
		bool isOutwall,
		bool isHorizontal
	) {
		this.position_X = position_X;
		this.position_Y = position_Y;
		this.isOpen = isOpen;
		this.isOutwall = isOutwall;
		this.isHorizontal = isHorizontal;
	}
	

}
