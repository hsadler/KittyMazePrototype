using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyService {

	// SERVICE FOR KITTIES


	private static string assetNamespace = "Kitty";
	private static string thumbAssetNamespace = "KittyThumb";


	public static KittyModel GetModelByAssetName(string assetName) {
		var assetNameToKittyModel = GameManager
			.instance
			.kittyData
			.GetAssetNameToModel();
		if(assetNameToKittyModel.ContainsKey(assetName)) {
			return assetNameToKittyModel[assetName];
		}
		return null;
	}

	public static void SaveMultiple(List<KittyModel> models) {
		GameManager.instance.kittyData.SaveModels(models);
	}

	public static void Save(KittyModel model) {
		var modelsToSave = new List<KittyModel>() { model };
		KittyService.SaveMultiple(modelsToSave);
	}

	public static List<KittyModel> GetAll() {
		return GameManager.instance.kittyData.GetModels();
	}

	public static KittyModel GetSelected() {
		// STUB
		return null;
	}

	public static void SetSelected(KittyModel model) {
		// STUB
	}

	public static string GetFormattedAssetAddress(string spriteName) {
		return KittyService.assetNamespace + "/" + spriteName;
	}

	public static string GetFormattedThumbAssetAddress(
		string spriteName,
		bool isThumbSpriteName=false
	) {
		string address = KittyService.thumbAssetNamespace + "/" + spriteName;
		if(!isThumbSpriteName) {
			address = address + "Thumb";
		}
		return address;
	}


}
