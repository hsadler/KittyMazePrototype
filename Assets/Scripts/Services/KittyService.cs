using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyService {

	// SERVICE FOR KITTIES

	private static string kittyAssetNamespace = "Kitty";
	private static string kittyThumbAssetNamespace = "KittyThumb";


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
		KittyService.SaveKitties(kittiesToSave);
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

	public static string GetFormattedKittyAssetAddress(string spriteName) {
		return KittyService.kittyAssetNamespace + "/" + spriteName;
	}

	public static string GetFormattedKittyThumbAssetAddress(string spriteName, bool isThumbSpriteName=false) {
		string address = KittyService.kittyThumbAssetNamespace + "/" + spriteName;
		if(!isThumbSpriteName) {
			address = address + "Thumb";
		}
		return address; 
	}


}
