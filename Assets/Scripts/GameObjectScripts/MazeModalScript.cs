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

	public bool itemIsUnlocked = false;


	// UNITY HOOKS

	void Start() {
		this.DoMazeProgressProcesses();
		this.unlockItemSectionGO.SetActive(false);
		this.buttonsSectionGO.SetActive(false);
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

	private void DoMazeProgressProcesses() {
		MazeProgressModel mazeProgressModel = MazeProgressService.GetModel();
		mazeProgressModel.currentProgress += 1;
		if(mazeProgressModel.currentProgress == MazeProgressModel.MAX_PROGRESS) {
			this.itemIsUnlocked = true;
			mazeProgressModel.currentProgress = 0;
		}
		MazeProgressService.Save(mazeProgressModel);
		print(
			"maze progress: " + 
			mazeProgressModel.currentProgress.ToString() + 
			"/" + 
			MazeProgressModel.MAX_PROGRESS.ToString()
		);
		print("item is unlocked: " + this.itemIsUnlocked.ToString());
	}

}
