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

	public static void SaveKitties(List<KittyModel> kittyModels) {
		GameManager.instance.kittyData.SaveModels(kittyModels);
	}

	public static void SaveKitty(KittyModel kitty) {
		var kittiesToSave = new List<KittyModel>() { kitty };
		Kitty.SaveKitties(kittiesToSave);
	}

	public static List<KittyModel> GetAllKitties() {
		return GameManager.instance.kittyData.GetModels();
	}

	public static KittyModel GetSelectedKitty() {
		// STUB
		return null;
	}

	public static void SetSelectedKitty(KittyModel kitty) {
		// STUB
	}


}
