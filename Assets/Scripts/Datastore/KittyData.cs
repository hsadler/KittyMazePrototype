using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KittyData {

	// DATA ACCESSOR AND STATE MANAGER FOR KITTY RECORDS


	private const string SAVE_DIR = "/";
	private const string SAVE_FILE = "kitty.json";

	private IDictionary<string, KittyModel> assetNameToKittyModel;


	public KittyData() {
		this.assetNameToKittyModel = new Dictionary<string, KittyModel>();
		this.InitDirectories();
		this.LoadRecords();
	}

	// INTERFACE METHODS
	
	public IDictionary<string, KittyModel> GetAssetNameToKittyModel() {
		return this.assetNameToKittyModel;
	}

	public List<KittyModel> GetModels() {
		return this.assetNameToKittyModel.Values.ToList();
	}

	public void SaveModels(List<KittyModel> models) {
		// add models if they don't yet exist
		foreach (var kittyModel in models) {
			if(!this.assetNameToKittyModel.ContainsKey(kittyModel.assetName)) {
				this.assetNameToKittyModel.Add(kittyModel.assetName, kittyModel);
			}
		}
		// commit models to json file
		this.SynchRecordsToJsonFile();
	}

	// IMPLEMENTATION METHODS

	private void InitDirectories() {
		string savePath = GetFormattedSaveDirPath();
		if(!Directory.Exists(savePath)) {
			Directory.CreateDirectory(savePath);
		}
	}

	private void LoadRecords() {
		string savePath = GetFormattedSaveFilePath();
		if(File.Exists(savePath)) {
			string json = File.ReadAllText(savePath);
			Debug.Log("Loaded json: " + json);
			var kittyModels = JsonUtility.FromJson<List<KittyModel>>(json);
			foreach (var kittyModel in kittyModels) {
				Debug.Log("kitty model asset name: " + kittyModel.assetName);
				this.assetNameToKittyModel.Add(
					kittyModel.assetName,
					kittyModel
				);
			}
		}
	}

	private void SynchRecordsToJsonFile() {
		this.InitDirectories();
		string json = JsonUtility.ToJson(
			this.assetNameToKittyModel.Values.ToList(), 
			true
		);
		Debug.Log("SynchRecordsToJsonFile json: " + json);
		File.WriteAllText(this.GetFormattedSaveFilePath(), json, Encoding.UTF8);
	}

	private string GetFormattedSaveDirPath() {
		return Application.persistentDataPath + SAVE_DIR;
	}

	private string GetFormattedSaveFilePath() {
		return Application.persistentDataPath + SAVE_DIR + SAVE_FILE;
	}


}
