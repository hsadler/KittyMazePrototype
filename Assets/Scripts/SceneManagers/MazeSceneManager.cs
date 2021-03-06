﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSceneManager : MonoBehaviour {


	// scene object prefabs
	public GameObject playerObjectPrefab;
	public GameObject mazeContainerPrefab;
	public GameObject mazeCellPrefab;
	public GameObject mazeWallPrefab;
	public GameObject mazeModalGO;
	
	// data models
	public Maze mazeModel;

	
	// the static reference to the singleton instance
	public static MazeSceneManager instance { get; private set; }

	// UNITY HOOKS

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
		var mazeGen = new MazeGeneratorService();
		this.mazeModel = mazeGen.GenerateMaze(11, 11);
	}

	void Start() {
		this.RenderMazeObjects();
		this.PlacePlayerObject();
		mazeModalGO.SetActive(false);
	}

	// INTERFACE METHODS

	public void MazeComplete() {
		this.mazeModalGO.SetActive(true);
	}

	// IMPLEMENTATION METHODS

	private void RenderMazeObjects() {
		GameObject mazeContainer = Instantiate(mazeContainerPrefab);
		Vector3 mazePosition = new Vector3(
			-(mazeModel.width / 2) + 1,
			-(mazeModel.height / 2),
			0
		);
		mazeContainer.transform.position = mazePosition;
		List<MazeCell> mazeCells = mazeModel.positionToMazeCell.Values.ToList();
		// instantiate maze cell game objects
		foreach (MazeCell mazeCellModel in mazeCells) {
			GameObject mazeCellGO = Instantiate(mazeCellPrefab, mazeContainer.transform);
			var mazeCellScript = mazeCellGO.GetComponent<MazeCellScript>();
			mazeCellScript.mazeCellModel = mazeCellModel;
		}
		List<MazeWall> mazeWalls = mazeModel.positionToMazeWall.Values.ToList();
		// instantiate maze wall game objects
		foreach (MazeWall mazeWallModel in mazeWalls) {
			GameObject mazeWallGO = Instantiate(mazeWallPrefab, mazeContainer.transform);
			var mazeWallScript = mazeWallGO.GetComponent<MazeWallScript>();
			mazeWallScript.mazeWallModel = mazeWallModel;
		}
	}

	private void PlacePlayerObject() {
		GameObject startPoint = GameObject.FindGameObjectWithTag("StartPoint");
		var pos = new Vector3(
			startPoint.transform.position.x, 
			startPoint.transform.position.y, 
			-1.5f
		); 
		GameObject.Instantiate(playerObjectPrefab, pos, Quaternion.identity);
	}

	
}
