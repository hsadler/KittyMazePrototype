﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator {

	// SERVICE FOR GENERATING MAZE DATA STRUCTURES


	const string NORTH = "NORTH";
	const string SOUTH = "SOUTH";
	const string EAST = "EAST";
	const string WEST = "WEST";


	// INTERFACE METHODS

	public Maze GenerateMaze(int width, int height) {
		var maze = this.GenerateInitializedMaze(width, height);
		maze = this.ApplyDepthFirstBacktrackingToMaze(maze);
		return maze;
	}

	public Maze GenerateInitializedMaze(int width, int height) {
		var positionToMazeCell = new Dictionary<string, MazeCell>();
		// keep track of the last maze cell
		MazeCell lastMazeCell = null;
		// for each position instantiate maze cells and 
		// point to previous maze cell to create linked list
		for(int i = 0; i < height; i++) {
			for(int j = 0; j < width; j++) {
				var mazeCell = new MazeCell(j, i);
				if(lastMazeCell != null) {
					mazeCell.nextMazeCell = lastMazeCell;
				}
				lastMazeCell = mazeCell;
				// add to position lookup dict
				positionToMazeCell.Add(
					GetFormattedMazeCellPosition(mazeCell.position_X, mazeCell.position_Y), 
					mazeCell
				);
			} 
		}
		// for every maze cell in the linked list set all the neighbor cells
		MazeCell currentMazeCell = lastMazeCell;
		MazeCell previousMazeCell = null;
		while(currentMazeCell != null) {
			var northNeighborCell = GetMazeCellNeighborCell(
				positionToMazeCell, 
				currentMazeCell, 
				MazeGenerator.NORTH
			);
			var southNeighborCell = GetMazeCellNeighborCell(
				positionToMazeCell, 
				currentMazeCell, 
				MazeGenerator.SOUTH
			);
			var eastNeighborCell = GetMazeCellNeighborCell(
				positionToMazeCell, 
				currentMazeCell, 
				MazeGenerator.EAST
			);
			var westNeighborCell = GetMazeCellNeighborCell(
				positionToMazeCell, 
				currentMazeCell, 
				MazeGenerator.WEST
			);
			// point maze cells to one another
			currentMazeCell.mazeCell_N = northNeighborCell;
			currentMazeCell.mazeCell_S = southNeighborCell;
			currentMazeCell.mazeCell_E = eastNeighborCell;
			currentMazeCell.mazeCell_W = westNeighborCell;
			// instantiate walls and assign to maze cells
			if(currentMazeCell.position_Y == 0) {
				// top row cell
				currentMazeCell.mazeWall_N = new MazeWall(false, true);
				currentMazeCell.mazeWall_S = new MazeWall(false, false);
			} else if(currentMazeCell.position_Y == height - 1) {
				// bottom row cell
				currentMazeCell.mazeWall_N = currentMazeCell.mazeCell_N.mazeWall_S;
				currentMazeCell.mazeWall_S = new MazeWall(false, true);
			} else {
				// inner row cell
				currentMazeCell.mazeWall_N = currentMazeCell.mazeCell_N.mazeWall_S;
				currentMazeCell.mazeWall_S = new MazeWall(false, false);
			}
			if(currentMazeCell.position_X == 0) {
				// left column
				currentMazeCell.mazeWall_W = new MazeWall(false, true);
				currentMazeCell.mazeWall_E = new MazeWall(false, false);
			} else if(currentMazeCell.position_X == width -1) {
				// right column
				currentMazeCell.mazeWall_W = currentMazeCell.mazeCell_W.mazeWall_E;
				currentMazeCell.mazeWall_E = new MazeWall(false, true);
			} else {
				// inner column
				currentMazeCell.mazeWall_W = currentMazeCell.mazeCell_W.mazeWall_E;
				currentMazeCell.mazeWall_E = new MazeWall(false, false);
			}
			previousMazeCell = currentMazeCell; 
			currentMazeCell = currentMazeCell.nextMazeCell;
		}
		return new Maze(width, height, positionToMazeCell, lastMazeCell);
	}

	public MazeCell GetMazeCellNeighborCell(
		Dictionary<string, MazeCell> positionToMazeCell, 
		MazeCell cell, 
		string neighborDirection
	) {
		string neighborPos = GetFormattedMazeCellPositionForNeighbor(
			cell, 
			neighborDirection
		);
		if(positionToMazeCell.ContainsKey(neighborPos)) {
			return positionToMazeCell[neighborPos];
		}
		return null;
	}

	public string GetFormattedMazeCellPosition(int posX, int posY) {
		return posX.ToString() + "," + posY.ToString();
	}

	public string GetFormattedMazeCellPositionForNeighbor(
		MazeCell cell, 
		string neighborDirection
	) {
		int posX = cell.position_X;
		int posY = cell.position_Y;
		if(neighborDirection == NORTH) {
			posY += 1;			
		} else if(neighborDirection == SOUTH) {
			posY -= 1;
		} else if(neighborDirection == WEST) {
			posX -= 1;
		} else if(neighborDirection == EAST) {
			posX += 1;
		}
		return this.GetFormattedMazeCellPosition(posX, posY);
	}

	// IMPLEMENTATION METHODS

	private Maze ApplyDepthFirstBacktrackingToMaze(Maze maze) {
		// STUB
		return maze;
	} 

}
