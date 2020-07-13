using System.Collections;
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

		var positionToMazeCell = new Dictionary<string, MazeCell>();
		
		// build maze graph
		
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
					GetFormattedMazeCellPosition(mazeCell), 
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

			// WORKING HERE...

			previousMazeCell = currentMazeCell; 
			currentMazeCell = currentMazeCell.nextMazeCell;
		}
		
		return new Maze();
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

	public string GetFormattedMazeCellPosition(MazeCell cell) {
		// STUB
		return "";
	}

	public string GetFormattedMazeCellPositionForNeighbor(
		MazeCell cell, 
		string neighborDirection
	) {
		// STUB
		return "";
	}

	// IMPLEMENTATION METHODS


}
