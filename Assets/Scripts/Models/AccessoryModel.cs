using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccessoryModel {

	// MODEL FOR ACCESSORY

	// TODO: add more properties as needed


	public string id;
	public string primaryAssetName;
	public string primaryAssetAddress;
	public string thumbAssetAddress;
	public string accessoryGroup;
	public string accessorySubGroup;


	public AccessoryModel(
		string id,
		string primaryAssetName,
		string primaryAssetAddress,
		string thumbAssetAddress,
		string accessoryGroup,
		string accessorySubGroup
	) {
		this.id = id;
		this.primaryAssetName = primaryAssetName;
		this.primaryAssetAddress = primaryAssetAddress;
		this.thumbAssetAddress = thumbAssetAddress;
		this.accessoryGroup = accessoryGroup;
		this.accessorySubGroup = accessorySubGroup;
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS


}
