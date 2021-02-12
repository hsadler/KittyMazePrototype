using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// GLOBAL GAME MANAGER


	public AssetData assetData;
	public KittyData kittyData;
	public AccessoryData accessoryData;
	public KittyAccessoryData kittyAccessoryData;
	public MazeProgressData mazeProgressData;
	
	public DataStartup dataStartup;
	public UnityEvents unityEvents;
	public AdminControl adminControl;


	// the static reference to the singleton instance
	public static GameManager instance { get; private set; }

	// UNITY HOOKS

	void Awake() {
		if(instance == null) {
			instance = this;
			this.Init();
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Start() {}

	// INTERFACE METHODS

	public void ToggleShowAllKittiesAndAccessories() {
        this.adminControl.showAllKittiesAndAccessories = 
			!this.adminControl.showAllKittiesAndAccessories;
    }

    public void ToggleEasyMazeMode() {
        this.adminControl.easyMazeMode = !this.adminControl.easyMazeMode;
    }

	public void ClearSaves() {
		// Debug.Log("Clearing Saves...");
		this.kittyData.DeleteSavedDataFile();
		this.kittyAccessoryData.DeleteSavedDataFile();
		this.Init();
	}

	// IMPLEMENTATION METHODS

	private void Init() {
		// instantiate datastores
		this.assetData = new AssetData();
		this.kittyData = new KittyData();
		this.accessoryData = new AccessoryData();
		this.kittyAccessoryData = new KittyAccessoryData();
		this.mazeProgressData = new MazeProgressData();
		// execute data startup processes
		this.dataStartup = new DataStartup();
		this.dataStartup.ExecuteStartupProcesses();
		// instantiate unity events object
		this.unityEvents = new UnityEvents();
		// instantiate admin control object
		this.adminControl = new AdminControl();
	}


}
