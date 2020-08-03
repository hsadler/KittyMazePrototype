using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KittyModel {

	// MODEL FOR KITTY


	public string id;
	public string primaryAssetName;
	public string primaryAssetAddress;
	public string thumbAssetAddress;
	public bool isUnlocked;
	public bool isSelected;


	public KittyModel(
		string id,
		string primaryAssetName,
		string primaryAssetAddress,
		string thumbAssetAddress,
		bool isUnlocked,
		bool isSelected
	) {
		this.id = id;
		this.primaryAssetName = primaryAssetName;
		this.primaryAssetAddress = primaryAssetAddress;
		this.thumbAssetAddress = thumbAssetAddress;
		this.isUnlocked = isUnlocked;
		this.isSelected = isSelected;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS
	

}
