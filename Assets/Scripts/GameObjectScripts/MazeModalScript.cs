using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeModalScript : MonoBehaviour {


	public GameObject progressSectionGO;
	public GameObject unlockItemSectionGO;
	
	public GameObject homeButtonGO;
	public GameObject dressUpButtonGO; 


	// UNITY HOOKS

	void Start() {}

	void Update() {}

	// INTERFACE METHODS
	
	public void ReloadMazeScene() {
		SceneManager.LoadScene("MazeScene");
	}

	public void GoToMainMenuScene() {
		SceneManager.LoadScene("MainMenuScene");
	}

	public void GoToDressUpScene() {
		SceneManager.LoadScene("DressUpScene");
	} 

	// IMPLEMENTATION METHODS


}
