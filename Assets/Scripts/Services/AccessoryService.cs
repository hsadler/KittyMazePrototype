using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryService {

	// SERVICE FOR ACCESSORIES


	private static string assetNamespace = "Accessory";
	private static string thumbAssetNamespace = "AccessoryThumb";


	public static AccessoryModel GetModelByAssetName(string assetName) {
		var assetNameToAccessoryModel = GameManager
			.instance
			.accessoryData
			.GetAssetNameToAccessoryModel();
		if(assetNameToAccessoryModel.ContainsKey(assetName)) {
			return assetNameToAccessoryModel[assetName];
		}
		return null;
	}

	public static void SaveMultiple(List<AccessoryModel> models) {
		GameManager.instance.accessoryData.SaveModels(models);
	}

	public static void Save(AccessoryModel model) {
		var modelsToSave = new List<AccessoryModel>() { model };
		AccessoryService.SaveMultiple(modelsToSave);
	}

	public static List<AccessoryModel> GetAll() {
		return GameManager.instance.accessoryData.GetModels();
	}

	public static string GetFormattedAssetAddress(string spriteName) {
		return AccessoryService.assetNamespace + "/" + spriteName;
	}

	public static string GetFormattedThumbAssetAddress(
		string spriteName,
		bool isThumbSpriteName=false
	) {
		string address = AccessoryService.thumbAssetNamespace + "/" + spriteName;
		if(!isThumbSpriteName) {
			address = address + "Thumb";
		}
		return address;
	}


}
