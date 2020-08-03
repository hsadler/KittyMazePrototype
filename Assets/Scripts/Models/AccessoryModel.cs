using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryModel {

	// MODEL FOR ACCESSORY


	public string id;
	public string primaryAssetName;
	public string primaryAssetAddress;
	public string thumbAssetAddress;
	public bool isUnlocked; 


	public AccessoryModel(
		string id,
		string primaryAssetName,
		string primaryAssetAddress,
		string thumbAssetAddress,
		bool isUnlocked
	) {
		this.id = id;
		this.primaryAssetName = primaryAssetName;
		this.primaryAssetAddress = primaryAssetAddress;
		this.thumbAssetAddress = thumbAssetAddress;
		this.isUnlocked = isUnlocked;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
