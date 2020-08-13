using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// GLOBAL GAME MANAGER


	public AssetData assetData;
	public KittyData kittyData;
	public AccessoryData accessoryData;
	public KittyAccessoryData kittyAccessoryData;
	
	public DataStartup dataStartup;
	public UnityEvents unityEvents;


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

	// IMPLEMENTATION METHODS

	private void Init() {
		// instantiate datastores
		this.assetData = new AssetData();
		this.kittyData = new KittyData();
		this.accessoryData = new AccessoryData();
		this.kittyAccessoryData = new KittyAccessoryData();
		// execute data startup processes
		this.dataStartup = new DataStartup();
		this.dataStartup.ExecuteStartupProcesses();
		// instantiate unity event object
		this.unityEvents = new UnityEvents();
	}


}
