using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccessoryData {

	// DATA STATE MANAGER FOR ACCESSORY RECORDS


	private const string SAVE_DIR = "/";
	private const string SAVE_FILE = "accessory.json";

	// use primary asset name as key for lookups
	private IDictionary<string, AccessoryModel> assetNameToModel;


	// CONSTRUCTOR

	public AccessoryData() {
		this.assetNameToModel = new Dictionary<string, AccessoryModel>();
		this.InitDirectories();
		this.LoadRecords();
	}

	// INTERFACE METHODS

	public IDictionary<string, AccessoryModel> GetAssetNameToModel() {
		return this.assetNameToModel;
	}

	public List<AccessoryModel> GetModels() {
		return this.assetNameToModel.Values.ToList();
	}

	public void SaveModels(List<AccessoryModel> models) {
		// add models if they don't yet exist
		foreach (var accessoryModel in models) {
			if(!this.assetNameToModel.ContainsKey(accessoryModel.primaryAssetName)) {
				this.assetNameToModel.Add(accessoryModel.primaryAssetName, accessoryModel);
			}
		}
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
			AccessorySave accessorySave = JsonUtility.FromJson<AccessorySave>(json);
			foreach (var accessoryModel in accessorySave.models) {
				// Debug.Log("accessory model asset name: " + accessoryModel.assetName);
				this.assetNameToModel.Add(
					accessoryModel.primaryAssetName,
					accessoryModel
				);
			}
		}
	}

	private void SynchRecordsToJsonFile() {
		this.InitDirectories();
		var accessorySave = new AccessorySave(this.GetModels());
		string json = JsonUtility.ToJson(
			accessorySave,
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
