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

	public static List<AccessoryModel> GetSelectedAccessoriesForKitty(
		KittyModel kittyModel
	) {
		// STUB
		return null;
	}

	public static void SetSelectedAccessoryForKitty(
		KittyModel kitty, 
		AccessoryModel accessory
	) {
		// STUB
	}

	public static string GetFormattedAssetDirectory(
		string accessoryGroup,
		string accessorySubGroup
	) {
		return AccessoryService.assetNamespace +
			"/" + accessoryGroup +
			"/" + accessorySubGroup;
	}

	public static string GetFormattedAssetAddress(
		string accessoryGroup,
		string accessorySubGroup,
		string spriteName
	) {
		return AccessoryService.assetNamespace +
			"/" + accessoryGroup +
			"/" + accessorySubGroup +
			"/" + spriteName;
	}

	public static string GetFormattedThumbAssetAddress(
		string accessoryGroup,
		string accessorySubGroup,
		string spriteName,
		bool isThumbSpriteName=false
	) {
		string address = AccessoryService.thumbAssetNamespace +
			"/" + accessoryGroup +
			"/" + accessorySubGroup +
			"/" + spriteName;
		if(!isThumbSpriteName) {
			address = address + "Thumb";
		}
		return address;
	}

	public static string GetFormattedThumbAssetDir(
		string accessoryGroup,
		string accessorySubGroup
	) {
		string dir = AccessoryService.thumbAssetNamespace +
			"/" + accessoryGroup +
			"/" + accessorySubGroup;
		return dir;
	}


}
