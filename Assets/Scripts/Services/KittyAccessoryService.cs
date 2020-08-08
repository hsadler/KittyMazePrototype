using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyAccessoryService {

	// SERVICE FOR KITTY -> ACCESSORY RELATIONSHIPS


	public static KittyAccessoryModel GetModelByKittyAndAccessoryCombination(
		KittyModel kittyModel, 
		AccessoryModel accessoryModel
	) {
		KittyAccessoryData kittyAccessoryData = GameManager.instance.kittyAccessoryData;
		string key = kittyAccessoryData.GetFormattedKeyFromKittyAndAccessoryCombination(
			kittyModel,
			accessoryModel
		);
		var keyToModel = kittyAccessoryData.GetKeyToModel();
		if(keyToModel.ContainsKey(key)) {
			return keyToModel[key];
		}
		return null;
	}

	public static void SaveMultiple(List<KittyAccessoryModel> models) {
		GameManager.instance.kittyAccessoryData.SaveModels(models);
	}

	public static void Save(KittyAccessoryModel model) {
		var modelsToSave = new List<KittyAccessoryModel>() { model };
		KittyAccessoryService.SaveMultiple(modelsToSave);
	}

	public static List<KittyAccessoryModel> GetAll() {
		return GameManager.instance.kittyAccessoryData.GetModels();
	}
	

}
