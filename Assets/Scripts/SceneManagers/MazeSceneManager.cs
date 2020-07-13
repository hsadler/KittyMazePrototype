using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSceneManager : MonoBehaviour {


	// scene objects
	public GameObject playerObject;
	
	// models
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
		var mazeGen = new MazeGenerator();
		this.mazeModel = mazeGen.GenerateMaze(10, 10);
	}

	void Start() {
		this.RenderMazeObjects();
		this.PlacePlayerObject();
	}

	// INTERFACE METHODS

	public void MazeComplete() {
		this.ReloadMazeScene();
	}

	// IMPLEMENTATION METHODS

	private void RenderMazeObjects() {
		// TODO: implement
		List<MazeCell> mazeCells = mazeModel.positionToMazeCell.Values.ToList();
		// instantiate maze cell game objects
		List<MazeWall> mazeWalls = mazeModel.positionToMazeWall.Values.ToList();
		// instantiate maze wall game objects
	}

	private void PlacePlayerObject() {
		GameObject startPoint = GameObject.FindGameObjectWithTag("StartPoint");
		var pos = new Vector3(
			startPoint.transform.position.x, 
			startPoint.transform.position.y, 
			0
		); 
		GameObject.Instantiate(playerObject, pos, Quaternion.identity);
	}

	private void ReloadMazeScene() {
		SceneManager.LoadScene("MazeScene");
	}

	
}
