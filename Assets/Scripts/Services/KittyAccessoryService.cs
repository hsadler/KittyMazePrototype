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

	public static List<KittyAccessoryModel> GetModelsByKittyIds(
		List<string> kittyIds
	) {
		var kittyIdToModel = new Dictionary<string, KittyAccessoryModel>();
		foreach (var model in KittyAccessoryService.GetAll()) {
			kittyIdToModel.Add(model.kittyId, model);
		}
		var resultModels = new List<KittyAccessoryModel>();
		foreach (string kittyId in kittyIds) {
			if (kittyIdToModel.ContainsKey(kittyId)) {
				resultModels.Add(kittyIdToModel[kittyId]);
			}
		}
		return resultModels;
	}

	public static List<KittyAccessoryModel> GetModelsByKittyId(string kittyId) {
		return KittyAccessoryService.GetModelsByKittyIds(
			new List<string>() { kittyId }
		);
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
