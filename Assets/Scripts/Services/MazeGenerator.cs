using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator {

	// SERVICE FOR GENERATING MAZE DATA STRUCTURES


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
			foreach(string direction in MazeCell.directions) {
				MazeCell nCell = this.GetMazeCellNeighborCellFromLookupDict(
					positionToMazeCell, 
					currentMazeCell, 
					direction
				);
				MazeWall sharedWall = null;
				if(nCell != null) {
					currentMazeCell.SetNeighborMazeCell(direction, nCell);
					sharedWall = nCell.GetMazeWall(MazeCell.GetOppositeDirection(direction));
				}
				if(sharedWall != null) {
					currentMazeCell.SetWall(direction, sharedWall);
				} else {
					float xOffset = 0;
					float yOffset = 0;
					if(direction == MazeCell.NORTH) {
						yOffset = 0.5f;
					} else if(direction == MazeCell.SOUTH) {
						yOffset = -0.5f;
					} else if(direction == MazeCell.EAST) {
						xOffset = 0.5f;
					} else if(direction == MazeCell.WEST) {
						xOffset = -0.5f;
					}
					bool isOutwall = (
						(direction == MazeCell.NORTH && currentMazeCell.position_Y == height -1) ||
						(direction == MazeCell.SOUTH && currentMazeCell.position_Y == 0) ||
						(direction == MazeCell.EAST && currentMazeCell.position_X == 0) ||
						(direction == MazeCell.WEST && currentMazeCell.position_X == width -1)
					);
					bool isHorizontal = direction == MazeCell.NORTH || direction == MazeCell.SOUTH;
					var mazeWall = new MazeWall(
						currentMazeCell.position_X + xOffset,
						currentMazeCell.position_Y + yOffset,
						true,
						isOutwall,
						isHorizontal
					); 
					currentMazeCell.SetWall(direction, mazeWall);
					positionToMazeCellWall.Add(
						this.GetFormattedPosition(
							mazeWall.position_X,
							mazeWall.position_Y
						), 
						mazeWall
					);
				}
			}
			previousMazeCell = currentMazeCell; 
			currentMazeCell = currentMazeCell.nextMazeCell;
		}

		var maze = new Maze(
			width, 
			height, 
			positionToMazeCell, 
			lastMazeCell, 
			positionToMazeCellWall
		);
		// this.TestValidateMaze(maze);

		return maze;
	}

	private MazeCell GetMazeCellNeighborCellFromLookupDict(
		Dictionary<string, MazeCell> positionToMazeCell, 
		MazeCell inputCell, 
		string neighborDirection
	) {
		string neighborPos = GetFormattedMazeCellPositionForNeighbor(
			inputCell, 
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
		if(neighborDirection == MazeCell.NORTH) {
			posY += 1;			
		} else if(neighborDirection == MazeCell.SOUTH) {
			posY -= 1;
		} else if(neighborDirection == MazeCell.WEST) {
			posX -= 1;
		} else if(neighborDirection == MazeCell.EAST) {
			posX += 1;
		}
		return this.GetFormattedPosition(posX, posY);
	}

	private Maze ApplyDepthFirstBacktrackingToMaze(Maze maze) {
		var backtrackMem = new Stack();
		var mazeCellsVisited = new Dictionary<string, MazeCell>();
		// select random cell to start and memorize
		MazeCell currentMazeCell = this.SelectRandomMazeCell(maze);
		MazeCell initialMazeCell = currentMazeCell;
		do {
			// mark current maze cell as visited
			string currPos = this.GetFormattedPosition(
				currentMazeCell.position_X, 
				currentMazeCell.position_Y
			); 
			if(!mazeCellsVisited.ContainsKey(currPos)) {
				mazeCellsVisited.Add(currPos, currentMazeCell);
			}
			// check for eligible direction
			string eligibleDirection = this.SearchForEligibleDirectionFromCell(
				currentMazeCell, 
				mazeCellsVisited
			);
			if(eligibleDirection != null) {
				// per the direction, remove the wall, memorize current maze cell, 
				// and move to neighbor maze cell
				var nCell = currentMazeCell.GetNeighborMazeCell(eligibleDirection);
				var wall = currentMazeCell.GetMazeWall(eligibleDirection);
				wall.isActive = false;
				backtrackMem.Push(currentMazeCell);
				currentMazeCell = nCell;
			} else {
				// backtrack one cell and try again in next loop
				currentMazeCell = (MazeCell)backtrackMem.Pop();
			}
		} while(currentMazeCell != initialMazeCell);
		return maze;
	} 
	
	private MazeCell SelectRandomMazeCell(Maze maze) {
		var mazeCells = maze.positionToMazeCell.Values.ToList();
		int randomIndex = Random.Range(0, mazeCells.Count);
		return mazeCells[randomIndex];
	}

	private string SearchForEligibleDirectionFromCell(
		MazeCell inputCell, 
		Dictionary<string, MazeCell> mazeCellsVisited
	) {
		List<string> shuffledDirections = Functions.ShuffleStringList(MazeCell.directions);
		foreach (string direction in shuffledDirections) {
			var nCell = inputCell.GetNeighborMazeCell(direction);
			if(nCell != null) {
				string nCellPos = this.GetFormattedPosition(nCell.position_X, nCell.position_Y);
				var wall = inputCell.GetMazeWall(direction);
				if(wall == null) {
					Debug.Log("wall not found..");
				}
				bool neighborCellIsEligible = ( 
					!mazeCellsVisited.ContainsKey(nCellPos) && 
					wall.isActive
				);
				if(neighborCellIsEligible) {
					return direction;
				}
			}
		}
		return null;
	}

	private void TestValidateMaze(Maze maze) {
		var mazeCells = maze.positionToMazeCell.Values.ToList();
		foreach(var cell in mazeCells) {
			foreach(var direction in MazeCell.directions) {
				var nCell = cell.GetNeighborMazeCell(direction);
				if(nCell == null) {
					Debug.Log(
						"neighbor maze cell not found for cell at position: " + 
						cell.position_X + ", " + 
						cell.position_Y + " and direction: " + direction
					);
				}
				var wall = cell.GetMazeWall(direction);
				if(wall == null) {
					Debug.Log(
						"wall not found for cell at position: " + 
						cell.position_X + ", " + 
						cell.position_Y + " and direction: " + direction
					); 
				}
			}
		}
	}


}
