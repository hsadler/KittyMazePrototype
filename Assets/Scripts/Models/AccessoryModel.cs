using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryModel {

	// MODEL FOR ACCESSORY

	// TODO: add more properties as needed


	public string id;
	public string primaryAssetName;
	public string primaryAssetAddress;
	public string thumbAssetAddress;
	public string accessoryGroup;
	public string accessorySubGroup;
	public bool isUnlocked;
	public bool isSelected;


	public AccessoryModel(
		string id,
		string primaryAssetName,
		string primaryAssetAddress,
		string thumbAssetAddress,
		string accessoryGroup,
		string accessorySubGroup,
		bool isUnlocked,
		bool isSelected
	) {
		this.id = id;
		this.primaryAssetName = primaryAssetName;
		this.primaryAssetAddress = primaryAssetAddress;
		this.thumbAssetAddress = thumbAssetAddress;
		this.accessoryGroup = accessoryGroup;
		this.accessorySubGroup = accessorySubGroup;
		this.isUnlocked = isUnlocked;
		this.isSelected = isSelected;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS


}
