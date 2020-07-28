using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyAccessoryModel {

	// MODEL FOR KITTY -> ACCESSORY RELATIONSHIPS


	public string kittyId;
	public string accessoryId;
	public bool isSelected;


	public KittyAccessoryModel(
		string kittyId,
		string accessoryId,
		bool isSelected
	) {
		this.kittyId = kittyId;
		this.accessoryId = accessoryId;
		this.isSelected = isSelected;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
