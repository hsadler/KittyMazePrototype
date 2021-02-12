using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KittyData {

	// DATA STATE MANAGER FOR KITTY RECORDS


	private const string SAVE_DIR = "/";
	private const string SAVE_FILE = "kitty.json";

	// use primary asset name as key for lookups
	private IDictionary<string, KittyModel> assetNameToModel;


	// CONSTRUCTOR

	public KittyData() {
		this.assetNameToModel = new Dictionary<string, KittyModel>();
		this.InitDirectories();
		this.LoadRecords();
	}

	// INTERFACE METHODS

	public IDictionary<string, KittyModel> GetAssetNameToModel() {
		return this.assetNameToModel;
	}

	public List<KittyModel> GetModels() {
		return this.assetNameToModel.Values.ToList();
	}

	public void SaveModels(List<KittyModel> models) {
		// foreach (var model in models) {
		// 	Debug.Log(model.primaryAssetAddress + " isSelected: " + model.isSelected.ToString());
		// }
		// add models if they don't yet exist
		foreach (var kittyModel in models) {
			if(!this.assetNameToModel.ContainsKey(kittyModel.primaryAssetName)) {
				this.assetNameToModel.Add(kittyModel.primaryAssetName, kittyModel);
			}
		}
		// commit models to json file
		this.SynchRecordsToJsonFile();
	}

	public void DeleteSavedDataFile() {
		// Debug.Log("Deleting Kitty Data JSON file");
		File.Delete(this.GetSavePath());
	}

	// IMPLEMENTATION METHODS

	private void InitDirectories() {
		string savePath = GetSaveDirPath();
		if(!Directory.Exists(savePath)) {
			Directory.CreateDirectory(savePath);
		}
	}

	private void LoadRecords() {
		string savePath = GetSavePath();
		if(File.Exists(savePath)) {
			string json = File.ReadAllText(savePath);
			// Debug.Log("Loaded json: " + json);
			KittySave kittySave = JsonUtility.FromJson<KittySave>(json);
			foreach (var kittyModel in kittySave.models) {
				// Debug.Log("kitty model asset name: " + kittyModel.assetName);
				this.assetNameToModel.Add(
					kittyModel.primaryAssetName,
					kittyModel
				);
			}
		}
	}

	private void SynchRecordsToJsonFile() {
		this.InitDirectories();
		var kittySave = new KittySave(this.GetModels());
		string json = JsonUtility.ToJson(
			kittySave,
			true
		);
		Debug.Log("SynchRecordsToJsonFile filepath: " + this.GetSavePath());
		// Debug.Log("SynchRecordsToJsonFile json: " + json);
		File.WriteAllText(this.GetSavePath(), json, Encoding.UTF8);
	}

	private string GetSaveDirPath() {
		return Application.persistentDataPath + SAVE_DIR;
	}

	private string GetSavePath() {
		return Application.persistentDataPath + SAVE_DIR + SAVE_FILE;
	}


}
