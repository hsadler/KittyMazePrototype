using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KittyAccessoryModel {

	// MODEL FOR KITTY -> ACCESSORY RELATIONSHIPS


	public string kittyId;
	public string accessoryId;
	public bool isUnlocked;
	public bool isSelected;


	public KittyAccessoryModel(
		string kittyId,
		string accessoryId,
		bool isUnlocked,
		bool isSelected
	) {
		this.kittyId = kittyId;
		this.accessoryId = accessoryId;
		this.isUnlocked = isUnlocked;
		this.isSelected = isSelected;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
