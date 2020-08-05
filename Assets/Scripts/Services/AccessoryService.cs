using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryService {

	// SERVICE FOR ACCESSORIES


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

	public static string GetFormattedAssetDirectory(
		string accessoryGroup, 
		string accessorySubgroup
	) {
		return AccessoryService.assetNamespace + 
			"/" + accessoryGroup + 
			"/" + accessorySubgroup;
	}

	public static string GetFormattedAssetAddress(
		string accessoryGroup, 
		string accessorySubgroup, 
		string spriteName
	) {
		return AccessoryService.assetNamespace + 
			"/" + accessoryGroup + 
			"/" + accessorySubgroup + 
			"/" + spriteName;
	}

	public static string GetFormattedThumbAssetAddress(
		string accessoryGroup, 
		string accessorySubgroup, 
		string spriteName,
		bool isThumbSpriteName=false
	) {
		string address = AccessoryService.thumbAssetNamespace + 
			"/" + accessoryGroup + 
			"/" + accessorySubgroup + 
			"/" + spriteName;
		if(!isThumbSpriteName) {
			address = address + "Thumb";
		}
		return address;
	}


}
