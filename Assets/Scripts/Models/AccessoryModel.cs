using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryModel {

	// MODEL FOR ACCESSORY


	public string id;
	public string assetName;
	public bool isUnlocked; 


	public AccessoryModel(
		string id,
		string assetName,
		bool isUnlocked
	) {
		this.id = id;
		this.assetName = assetName;
		this.isUnlocked = isUnlocked;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
