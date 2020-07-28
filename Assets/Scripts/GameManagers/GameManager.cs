using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// GLOBAL GAME MANAGER


	public DataStartup dataStartup;

	
	// the static reference to the singleton instance
	public static GameManager instance { get; private set; }

	// UNITY HOOKS

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		// execute data startup processes
		this.dataStartup = new DataStartup();
		this.dataStartup.ExecuteStartupProcesses();
	}

	void Start() {}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	
}
