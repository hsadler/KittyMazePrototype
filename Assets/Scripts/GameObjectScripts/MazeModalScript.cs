using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeModalScript : MonoBehaviour {


	public GameObject progressSectionGO;
	public GameObject checkmark1GO;
	public GameObject checkmark2GO;
	public GameObject checkmark3GO;

	public GameObject unlockItemSectionGO;
	public Image unlockItemImage;

	public GameObject buttonsSectionGO;
	public GameObject homeButtonGO;
	public GameObject dressUpButtonGO; 


	// UNITY HOOKS

	void Start() {
		unlockItemSectionGO.SetActive(false);
		buttonsSectionGO.SetActive(false);
	}

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
