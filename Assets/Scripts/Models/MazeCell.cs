using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell {

	// MODEL FOR MAZE CELL

	public const string NORTH = "NORTH";
	public const string SOUTH = "SOUTH";
	public const string EAST = "EAST";
	public const string WEST = "WEST";

	public static List<string> directions = new List<string>()
		{ NORTH, SOUTH, EAST, WEST };
	public static IDictionary<string, string> directionToOpposite = 
		new Dictionary<string, string>()
		{
			{NORTH, SOUTH},
			{SOUTH, NORTH},
			{EAST, WEST},
			{WEST, EAST},
		};

	public int position_X;
	public int position_Y;

	public MazeCell nextMazeCell;

	public IDictionary<string, MazeCell> directionToMazeCell = 
		new Dictionary<string, MazeCell>();

	public IDictionary<string, MazeWall> directionToMazeWall = 
		new Dictionary<string, MazeWall>();

	public bool generationVisited = false;
	public bool playerVisited = false;


	public MazeCell(int position_X, int position_Y) {
		this.position_X = position_X;
		this.position_Y = position_Y;
	}

	// INTERFACE METHODS

	public MazeCell GetNeighborMazeCell(string direction) {
		if(this.directionToMazeCell.ContainsKey(direction)) {
			return directionToMazeCell[direction];
		}
		return null;
	}

	public bool SetNeighborMazeCell(string direction, MazeCell mazeCell) {
		this.directionToMazeCell.Add(direction, mazeCell);
		return true;
	}

	public MazeWall GetMazeWall(string direction) {
		if(this.directionToMazeWall.ContainsKey(direction)) {
			return directionToMazeWall[direction];
		}
		return null;
	}

	public bool SetWall(string direction, MazeWall mazeWall) {
		this.directionToMazeWall.Add(direction, mazeWall);
		return true;
	}

	public static string GetOppositeDirection(string direction) {
		return directionToOpposite[direction];
	}

	// IMPLEMENTATION METHODS


}
