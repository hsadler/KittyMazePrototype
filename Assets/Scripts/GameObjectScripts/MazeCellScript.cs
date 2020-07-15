using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCellScript : MonoBehaviour {


	public MazeCell mazeCellModel;
	
	
	void Start() {
		transform.localPosition = new Vector3(
			mazeCellModel.position_X, 
			mazeCellModel.position_Y, 
			-1
		);
	}

	void Update() {}


}
