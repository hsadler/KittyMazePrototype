using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSceneManager : MonoBehaviour {


	// scene managers
	public MazeSceneObjective mazeSceneObjective;
	public MazeSceneObjectPlacement mazeSceneObjectPlacement;

	// scene objects
	public GameObject playerObject;

	
	// the static reference to the singleton instance
	public static MazeSceneManager instance { get; private set; }

	// UNITY HOOKS

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
		this.mazeSceneObjective = new MazeSceneObjective();
		this.mazeSceneObjectPlacement = new MazeSceneObjectPlacement();
	}

	void Start() {
		PlacePlayerObject();
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void PlacePlayerObject() {
		GameObject startPoint = GameObject.FindGameObjectWithTag("StartPoint");
		var pos = new Vector3(
			startPoint.transform.position.x, 
			startPoint.transform.position.y, 
			0
		); 
		GameObject.Instantiate(playerObject, pos, Quaternion.identity);
	}

	
}
