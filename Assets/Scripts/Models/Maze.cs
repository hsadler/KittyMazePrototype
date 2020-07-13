using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze {

	// MODEL FOR MAZE


	public int width;
	public int height;
	public IDictionary<string, MazeCell> positionToMazeCell;
	public MazeCell headMazeCell;
	public IDictionary<string, MazeWall> positionToMazeWall;


	public Maze(
		int width, 
		int height, 
		Dictionary<string, MazeCell> positionToMazeCell, 
		MazeCell headMazeCell,
		Dictionary<string, MazeWall> positionToMazeWall
	) {
		this.width = width;
		this.height = height;
		this.positionToMazeCell = positionToMazeCell;
		this.headMazeCell = headMazeCell;
		this.positionToMazeWall = positionToMazeWall;
	}
	

}
