﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyScrollContentItemScript : MonoBehaviour {


	public Image kittyImage;
	public KittyModel kittyModel;

	
	void Start() {}

	void Update() {}

	public void SelectKitty() {
		// print("selecting kitty: " + this.kittyModel.primaryAssetAddress);
		KittyService.SetSelected(this.kittyModel);
	}


}
