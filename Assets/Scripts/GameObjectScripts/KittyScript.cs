using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyScript : MonoBehaviour {


    public GameObject kittyContainer;
    public GameObject bowContainer;
    public GameObject scarfContainer;
    public GameObject bootsContainer;


    // UNITY HOOKS

    void Start() {
        // example of loading resources by name
        GameObject bowBlue = Resources.Load<GameObject>("BowBlue");
        Instantiate(bowBlue, this.gameObject.transform);
    }

    void Update() {}


}
