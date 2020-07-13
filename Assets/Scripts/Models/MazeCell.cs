using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell {

	// MODEL FOR MAZE CELL


	public int position_X;
	public int position_Y;

	public MazeCell nextMazeCell;

	public MazeCell mazeCell_N;
	public MazeCell mazeCell_S;
	public MazeCell mazeCell_E;
	public MazeCell mazeCell_W;

	public MazeWall mazeWall_N;
	public MazeWall mazeWall_S;
	public MazeWall mazeWall_E;
	public MazeWall mazeWall_W;

	public bool generationVisited = false;
	public bool playerVisited = false;


	public MazeCell(int position_X, int position_Y) {
		this.position_X = position_X;
		this.position_Y = position_Y;
	}


}
