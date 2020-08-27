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

	public int mazeProgress = 0;
	public bool itemIsUnlocked = false;
	

	// UNITY HOOKS

	void Start() {
		this.DoMazeProgressProcesses();
		this.unlockItemSectionGO.SetActive(false);
		this.buttonsSectionGO.SetActive(true);
	}
	
	void Update() {
		this.RenderCheckmarks();
		this.RenderButtons();
	}

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
		this.mazeProgress = mazeProgressModel.currentProgress;
		if (mazeProgressModel.currentProgress == MazeProgressModel.MAX_PROGRESS) {
			this.UnlockRandomKittyOrAccessory();
			this.itemIsUnlocked = true;
			mazeProgressModel.currentProgress = 0;
			this.RenderItemUnlock();
		}
		MazeProgressService.Save(mazeProgressModel);
		//print(
		//	"maze progress: " + 
		//	mazeProgressModel.currentProgress.ToString() + 
		//	"/" + 
		//	MazeProgressModel.MAX_PROGRESS.ToString()
		//);
		//print("item is unlocked: " + this.itemIsUnlocked.ToString());
	}

	// chose, at random, one item among the 
	// locked accessories and locked kitties for unlock
	private void UnlockRandomKittyOrAccessory() {
		//print("Unlocking random kitty or accessory...");
		// chance list for calculating selection of kitty or accessory for unlock
		var selectBetweenList = new List<int>();
		// gather objects
		var allKitties = KittyService.GetAll();
		var selectedKitty = KittyService.GetSelected();
		var accessoriesForKitty = AccessoryService.GetAccessoriesForKitty(selectedKitty);
		// filter for locked kitties and accessories
		var lockedKitties = new List<KittyModel>();
		foreach (var kitty in allKitties) {
			if (!kitty.isUnlocked) {
				lockedKitties.Add(kitty);
				selectBetweenList.Add(1);
			}
		}
		var lockedAccessoriesForKitty = new List<AccessoryModel>();
		foreach (var accessory in accessoriesForKitty) {
			var kittyAccessory = KittyAccessoryService.GetModelByKittyAndAccessoryCombination(
				selectedKitty,
				accessory
			);
			if (!kittyAccessory.isUnlocked) {
				lockedAccessoriesForKitty.Add(accessory);
				selectBetweenList.Add(2);
			}
		}
		// select whether kitty or accessory will be unlocked
		int randomSelectionIndex = Random.Range(0, selectBetweenList.Count);
		int selectedType = selectBetweenList[randomSelectionIndex];
		//print("selectBetweenList: " + System.String.Join(",", selectBetweenList));
		//print("selected Type: " + selectedType.ToString());
		if (selectedType == 1) {
			// unlock random locked kitty
			randomSelectionIndex = Random.Range(0, lockedKitties.Count);
			var kittyToUnlock = lockedKitties[randomSelectionIndex];
			kittyToUnlock.isUnlocked = true;
			KittyService.Save(kittyToUnlock);
		} else {
			// unlock random accessory for kitty
			randomSelectionIndex = Random.Range(0, lockedAccessoriesForKitty.Count);
			var accessoryToUnlock = lockedAccessoriesForKitty[randomSelectionIndex];
			var kittyAccessoryToUnlock = KittyAccessoryService.GetModelByKittyAndAccessoryCombination(
				selectedKitty,
				accessoryToUnlock
			);
			kittyAccessoryToUnlock.isUnlocked = true;
			KittyAccessoryService.Save(kittyAccessoryToUnlock);
		}
	}

	private void RenderCheckmarks() {
		this.checkmark1GO.SetActive(false);
		this.checkmark2GO.SetActive(false);
		this.checkmark3GO.SetActive(false);
		if (this.mazeProgress > 0) {
			this.checkmark1GO.SetActive(true);
		}
		if (this.mazeProgress > 1) {
			this.checkmark2GO.SetActive(true);
		}
		if (this.itemIsUnlocked) {
			this.checkmark3GO.SetActive(true);
		}
	}

	private void RenderItemUnlock() {
		// stub
		print("rendering item unlock...");
	}

	private void RenderButtons() {
		this.homeButtonGO.SetActive(false);
		this.dressUpButtonGO.SetActive(false);
		if (this.itemIsUnlocked) {
			this.dressUpButtonGO.SetActive(true);
		}
		else {
			this.homeButtonGO.SetActive(true);
		}
	}


}
