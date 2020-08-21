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

	public static List<AccessoryModel> GetModelsByIds(
		List<string> accessoryIds
	) {
		var idToModel = new Dictionary<string, AccessoryModel>();
        foreach (var model in AccessoryService.GetAll()) {
			idToModel.Add(model.id, model);
		}
		var resultModels = new List<AccessoryModel>();
		foreach (string id in accessoryIds) {
			if (idToModel.ContainsKey(id)) {
				resultModels.Add(idToModel[id]);
			}
		}
		return resultModels;
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

	public static List<AccessoryModel> GetAccessoriesForKitty(
		KittyModel kittyModel
	) {
		var selectedAccessoryIds = new List<string>();
		foreach(var kittyAccessoryModel in KittyAccessoryService.GetAll()) {
			if(kittyAccessoryModel.kittyId == kittyModel.id) {
				selectedAccessoryIds.Add(kittyAccessoryModel.accessoryId);
			}
		}
		return AccessoryService.GetModelsByIds(selectedAccessoryIds);
	}

	public static List<AccessoryModel> GetSelectedAccessoriesForKitty(
		KittyModel kittyModel
	) {
		var selectedAccessoryIds = new List<string>();
		foreach(var kittyAccessoryModel in KittyAccessoryService.GetAll()) {
			if(
				kittyAccessoryModel.kittyId == kittyModel.id &&
				kittyAccessoryModel.isSelected
			) {
				selectedAccessoryIds.Add(kittyAccessoryModel.accessoryId);
			}
		}
		return AccessoryService.GetModelsByIds(selectedAccessoryIds);
	}

	public static void SetSelectedAccessoryForKitty(
		KittyModel kitty,
		AccessoryModel accessory
	) {
		var kittyAccessoriesForKitty = KittyAccessoryService.GetModelsByKittyId(
			kitty.id
		);
		// mutate the kittyAccessory objects to ensure only one in the
		// group+subgroup is selected and save
		foreach (var kittyAccessoryModel in kittyAccessoriesForKitty) {
			if(
				kittyAccessoryModel.accessoryGroup == accessory.accessoryGroup &&
				kittyAccessoryModel.accessorySubGroup == accessory.accessorySubGroup
			) {
				if(kittyAccessoryModel.accessoryId == accessory.id) {
					kittyAccessoryModel.isSelected = true;
				} else {
					kittyAccessoryModel.isSelected = false;
				}
			}
		}
		KittyAccessoryService.SaveMultiple(KittyAccessoryService.GetAll());
	}

	public static void ToggleSelectedAccessoryForKitty(
		KittyModel kitty,
		AccessoryModel accessory
	) {
		var kittyAccessoriesForKitty = KittyAccessoryService.GetModelsByKittyId(
			kitty.id
		);
		// mutate the kittyAccessory objects to ensure only one in the
		// group+subgroup is selected and save
		foreach (var kittyAccessoryModel in kittyAccessoriesForKitty) {
			if(
				kittyAccessoryModel.accessoryGroup == accessory.accessoryGroup &&
				kittyAccessoryModel.accessorySubGroup == accessory.accessorySubGroup
			) {
				if(kittyAccessoryModel.accessoryId == accessory.id) {
					kittyAccessoryModel.isSelected = !kittyAccessoryModel.isSelected;
				} else {
					kittyAccessoryModel.isSelected = false;
				}
			}
		}
		KittyAccessoryService.SaveMultiple(KittyAccessoryService.GetAll());
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
