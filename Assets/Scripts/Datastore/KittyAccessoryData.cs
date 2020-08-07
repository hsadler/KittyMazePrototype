using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KittyAccessoryData {

	// DATA ACCESSOR FOR KITTY ACCESSORY RECORDS


	private const string SAVE_DIR = "/";
	private const string SAVE_FILE = "kitty-accessory.json";

	// use kitty+accessory compound key for lookups
	private IDictionary<string, KittyAccessoryModel> keyToModel;


	// CONSTRUCTOR

	public KittyAccessoryData() {
		this.keyToModel = new Dictionary<string, KittyAccessoryModel>();
		this.InitDirectories();
		this.LoadRecords();
	}

	// INTERFACE METHODS

	public IDictionary<string, KittyAccessoryModel> GetKeyToModel() {
		return this.keyToModel;
	}

	public List<KittyAccessoryModel> GetModels() {
		return this.keyToModel.Values.ToList();
	}

	public void SaveModels(List<KittyAccessoryModel> models) {
		// add models if they don't yet exist
		// TODO: FIX THIS
		// foreach (var model in models) {
		// 	if(!this.keyToModel.ContainsKey(accessoryModel.primaryAssetName)) {
		// 		this.keyToModel.Add(accessoryModel.primaryAssetName, accessoryModel);
		// 	}
		// }
		// commit models to json file
		this.SynchRecordsToJsonFile();
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
			var kittyAccessorySave = JsonUtility.FromJson<KittyAccessorySave>(json);
			foreach (var kittyAccessoryModel in kittyAccessorySave.models) {
				// Debug.Log("accessory model asset name: " + accessoryModel.assetName);
				// TODO: FIX THIS
				// this.keyToModel.Add(
				// 	accessoryModel.primaryAssetName,
				// 	accessoryModel
				// );
			}
		}
	}

	private void SynchRecordsToJsonFile() {
		this.InitDirectories();
		var kittyAccessorySave = new KittyAccessorySave(this.GetModels());
		string json = JsonUtility.ToJson(
			kittyAccessorySave,
			true
		);
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
