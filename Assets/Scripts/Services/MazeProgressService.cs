using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeProgressService {

	// SERVICE FOR MAZE-PROGRESS


	public static MazeProgressModel GetModel() {
		return GameManager.instance.mazeProgressData.GetModel();
	}

	public static void Save(MazeProgressModel model) {
		GameManager.instance.mazeProgressData.SaveModel(model);
	}


}
