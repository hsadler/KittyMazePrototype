using System.Collections;
using System.Collections.Generic;

public class MazeWall {

	// MODEL FOR MAZE WALL


	public float position_X;
	public float position_Y;

	public bool isActive = true;
	public bool isOutwall = false;
	public bool isHorizontal = false;


	public MazeWall(
		float position_X, 
		float position_Y, 
		bool isActive, 
		bool isOutwall,
		bool isHorizontal
	) {
		this.position_X = position_X;
		this.position_Y = position_Y;
		this.isActive = isActive;
		this.isOutwall = isOutwall;
		this.isHorizontal = isHorizontal;
	}
	

}
