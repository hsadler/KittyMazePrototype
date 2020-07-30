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


	// TODO: implement

	public KittyData() {
		this.assetNameToKittyModel = new Dictionary<string, KittyModel>();
		this.InitDirectories();
		this.LoadRecords();
	}

	// INTERFACE METHODS

	public List<KittyModel> GetModels() {
		return this.assetNameToKittyModel.Values.ToList();
	}

	public IDictionary<string, KittyModel> GetAssetNameToKittyModel() {
		return this.assetNameToKittyModel;
	}

	public bool SaveModel(KittyModel model) {
		// STUB
		return true;
	}

	// IMPLEMENTATION METHODS

	private void InitDirectories() {
		string savePath = GetFormattedSavePath();
		if(!Directory.Exists(savePath)) {
			Directory.CreateDirectory(savePath);
		}
	}

	private void LoadRecords() {
		string savePath = GetFormattedSavePath();
		if(File.Exists(savePath)) {
			string json = File.ReadAllText(savePath);
			Debug.Log(json);
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
		// string json = JsonUtility.ToJson(this.kittyModels);
	}

	private string GetFormattedSavePath() {
		return Application.persistentDataPath + SAVE_DIR + SAVE_FILE;
	}


}
