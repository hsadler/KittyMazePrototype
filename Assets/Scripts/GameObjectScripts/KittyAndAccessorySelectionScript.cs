using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyAndAccessorySelectionScript : MonoBehaviour {


	public GameObject kittySelectScrollList;
	public GameObject kittyAccessoriesScrollList;
	

	// UNITY HOOKS
	
	void Start() {}
	void Update() {}

	// INTERFACE METHODS

	public void SwitchToKittySelectScrollList() {
		kittyAccessoriesScrollList.SetActive(true);
		kittyAccessoriesScrollList.SetActive(false);
	}

	public void SwitchToKittyAccessoriesScrollList() {
		kittyAccessoriesScrollList.SetActive(false);
		kittyAccessoriesScrollList.SetActive(true);
	}


}
