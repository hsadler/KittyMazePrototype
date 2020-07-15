using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWallScript : MonoBehaviour {


	public MazeWall mazeWallModel;
	public GameObject wall;
	
	
	void Start() {
		transform.localPosition = new Vector3(
			mazeWallModel.position_X, 
			mazeWallModel.position_Y, 
			-1
		);
		if(mazeWallModel.isHorizontal) {
			float zRotation = 90.0f;
			transform.eulerAngles = new Vector3(
				transform.eulerAngles.x, 
				transform.eulerAngles.y, 
				zRotation
			);
		}
	}

	void Update() {
		if(mazeWallModel.isActive != wall.activeSelf) {
			wall.SetActive(mazeWallModel.isActive);
		}
	}


}
