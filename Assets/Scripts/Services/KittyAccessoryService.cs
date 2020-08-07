using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyAccessoryService {

	// SERVICE FOR KITTY -> ACCESSORY RELATIONSHIPS


	// TODO: implement

	// SERVICE FOR ACCESSORIES


	// EXAMPLE
	private static string assetNamespace = "Accessory";
	private static string thumbAssetNamespace = "AccessoryThumb";

	public static List<string> accessoryGroups = new List<string>
	{ "Head", "Feet", "Body", "Tail" };
	public static List<string> accessorySubGroups = new List<string>
	{ "L1", "M1", "N1" };


	public static AccessoryModel GetModelByAssetName(string assetName) {
		var assetNameToAccessoryModel = GameManager
			.instance
			.accessoryData
			.GetAssetNameToModel();
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
	

}
