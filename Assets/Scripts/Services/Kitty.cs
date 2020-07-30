using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitty {

	// SERVICE FOR KITTIES


	// TODO: implement

	public static KittyModel GetKittyByAssetName(string assetName) {
		var assetNameToKittyModel = GameManager
			.instance
			.kittyData
			.GetAssetNameToKittyModel();
		if(assetNameToKittyModel.ContainsKey(assetName)) {
			return assetNameToKittyModel[assetName];
		}
		return null;
	}


}
