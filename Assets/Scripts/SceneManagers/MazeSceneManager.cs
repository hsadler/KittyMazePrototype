using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSceneManager : MonoBehaviour {


    public MazeSceneObjective mazeSceneObjective;

    
    // the static reference to the singleton instance
	public static MazeSceneManager instance { get; private set; }

	// UNITY HOOKS

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
        this.mazeSceneObjective = new MazeSceneObjective();
	}

    
}
