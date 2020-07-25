using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavScript : MonoBehaviour {


	public void NavToMainMenuScene() {
		SceneManager.LoadScene("MainMenuScene");
	}

	public void NavToMazeScene() {
		SceneManager.LoadScene("MazeScene");
	}

	public void NavToDressUpScene() {
		SceneManager.LoadScene("DressUpScene");
	}


}
