using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	
	// IMPLEMENTATION METHODS

	private Maze GenerateInitializedMaze(int width, int height) {
		var positionToMazeCell = new Dictionary<string, MazeCell>();
		var positionToMazeCellWall = new Dictionary<string, MazeWall>();
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
					GetFormattedPosition(mazeCell.position_X, mazeCell.position_Y), 
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
				// bottom row cell
				currentMazeCell.mazeWall_N = new MazeWall(
					currentMazeCell.position_X,
					currentMazeCell.position_Y + 0.5f,
					false, 
					false,
					true
				);
				currentMazeCell.mazeWall_S = new MazeWall(
					currentMazeCell.position_X,
					currentMazeCell.position_Y - 0.5f,
					false, 
					true,
					true
				);
			} else if(currentMazeCell.position_Y == height - 1) {
				// top row cell
				currentMazeCell.mazeWall_N = new MazeWall(
					currentMazeCell.position_X,
					currentMazeCell.position_Y + 0.5f,
					false, 
					true,
					true
				);
				currentMazeCell.mazeWall_S = southNeighborCell.mazeWall_N;
			} else {
				// inner row cell
				currentMazeCell.mazeWall_N = new MazeWall(
					currentMazeCell.position_X,
					currentMazeCell.position_Y + 0.5f,
					false, 
					false,
					true
				);
				currentMazeCell.mazeWall_S = southNeighborCell.mazeWall_N;
			}
			if(currentMazeCell.position_X == 0) {
				// left column
				currentMazeCell.mazeWall_W = new MazeWall(
					currentMazeCell.position_X - 0.5f,
					currentMazeCell.position_Y,
					false, 
					true,
					false
				);
				currentMazeCell.mazeWall_E = new MazeWall(
					currentMazeCell.position_X + 0.5f,
					currentMazeCell.position_Y,
					false, 
					false,
					false
				);
			} else if(currentMazeCell.position_X == width -1) {
				// right column
				currentMazeCell.mazeWall_W = currentMazeCell.mazeCell_W.mazeWall_E;
				currentMazeCell.mazeWall_E = new MazeWall(
					currentMazeCell.position_X + 0.5f,
					currentMazeCell.position_Y,
					false, 
					true,
					false
				);
			} else {
				// inner column
				currentMazeCell.mazeWall_W = currentMazeCell.mazeCell_W.mazeWall_E;
				currentMazeCell.mazeWall_E = new MazeWall(
					currentMazeCell.position_X + 0.5f,
					currentMazeCell.position_Y,
					false, 
					false,
					false
				);
			}
			
			// add maze cell walls to dict
			if(currentMazeCell.mazeWall_N != null) {
				positionToMazeCellWall.Add(
					this.GetFormattedPosition(
						currentMazeCell.mazeWall_N.position_X, 
						currentMazeCell.mazeWall_N.position_Y
					), 
					currentMazeCell.mazeWall_N
				);
			}
			if(currentMazeCell.mazeWall_S != null) {
				positionToMazeCellWall.Add(
					this.GetFormattedPosition(
						currentMazeCell.mazeWall_S.position_X, 
						currentMazeCell.mazeWall_S.position_Y
					), 
					currentMazeCell.mazeWall_S
				);
			}
			if(currentMazeCell.mazeWall_E != null) {
				positionToMazeCellWall.Add(
					this.GetFormattedPosition(
						currentMazeCell.mazeWall_E.position_X, 
						currentMazeCell.mazeWall_E.position_Y
					), 
					currentMazeCell.mazeWall_E
				);
			}
			if(currentMazeCell.mazeWall_W != null) {
				positionToMazeCellWall.Add(
					this.GetFormattedPosition(
						currentMazeCell.mazeWall_W.position_X, 
						currentMazeCell.mazeWall_W.position_Y
					), 
					currentMazeCell.mazeWall_W
				);
			}

			previousMazeCell = currentMazeCell; 
			currentMazeCell = currentMazeCell.nextMazeCell;
		}
		return new Maze(
			width, 
			height, 
			positionToMazeCell, 
			lastMazeCell, 
			positionToMazeCellWall
		);
	}

	private MazeCell GetMazeCellNeighborCell(
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

	private string GetFormattedPosition(float posX, float posY) {
		return posX.ToString() + "," + posY.ToString();
	}

	private string GetFormattedMazeCellPositionForNeighbor(
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
		return this.GetFormattedPosition(posX, posY);
	}

	private Maze ApplyDepthFirstBacktrackingToMaze(Maze maze) {

		// STUB
		// TODO: implement

		var backtrackMem = new List<MazeCell>();
		var mazeCellsVisited = new Dictionary<string, MazeCell>();
		// select random cell to start and memorize
		MazeCell currentMazeCell = this.SelectRandomMazeCell(maze);
		MazeCell initialMazeCell = currentMazeCell;
		do {
			// #1 search for random direction
			// if available:
				// move to next cell and remove wall
				// put previous cell in mem stack
				// goto #1
			// else:
				// backtrack 1 cell
				// goto #1
		} while(currentMazeCell != initialMazeCell);
		return maze;
	} 
	
	private MazeCell SelectRandomMazeCell(Maze maze) {
		var mazeCells = maze.positionToMazeCell.Values.ToList();
		int randomIndex = Random.Range(0, mazeCells.Count);
		return mazeCells[randomIndex];
	}

	// private MazeCell SearchForRandomNeighborMazeCellFromCell(
	// 	MazeCell inputCell, 
	// 	Dictionary<string, MazeCell> mazeCellsVisited
	// ) {

	// }


}
