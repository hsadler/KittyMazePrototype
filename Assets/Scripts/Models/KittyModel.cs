using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KittyModel {

	// MODEL FOR KITTY


	public string id;
	public string assetName;
	public bool isUnlocked; 
	public bool isSelected;


	public KittyModel(
		string id,
		string assetName,
		bool isUnlocked,
		bool isSelected
	) {
		this.id = id;
		this.assetName = assetName;
		this.isUnlocked = isUnlocked;
		this.isSelected = isSelected;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
