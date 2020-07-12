using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSceneManager : MonoBehaviour {


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
	}

	void Start() {
		this.PlacePlayerObject();
	}

	// INTERFACE METHODS

	public void MazeComplete() {
		this.ReloadMazeScene();
	}

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

	private void ReloadMazeScene() {
		SceneManager.LoadScene("MazeScene");
	}

	
}
