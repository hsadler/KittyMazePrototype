using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour {


    // UNITY HOOKS

    void Start() {}

    void Update() {}

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "PlayerObject") {
            MazeSceneManager.instance.MazeComplete();
        }
    }


}
