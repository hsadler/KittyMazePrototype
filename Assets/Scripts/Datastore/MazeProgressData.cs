using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeProgressData {

	// DATA STATE MANAGER FOR MAZE-PROGRESS RECORDS


	private const string SAVE_DIR = "/";
	private const string SAVE_FILE = "maze-progression.json";

	private MazeProgressModel mazeProgressModel;


	// CONSTRUCTOR

	public MazeProgressData() {
		this.mazeProgressModel = new MazeProgressModel(0);
		this.InitDirectories();
		this.LoadRecord();
	}

	// INTERFACE METHODS

	public MazeProgressModel GetModel() {
		return this.mazeProgressModel;
	}

	public void SaveModel(MazeProgressModel model) {
		this.mazeProgressModel = model;
		this.SynchRecordToJsonFile();
	}

	// IMPLEMENTATION METHODS

	private void InitDirectories() {
		string savePath = GetSaveDirPath();
		if(!Directory.Exists(savePath)) {
			Directory.CreateDirectory(savePath);
		}
	}

	private void LoadRecord() {
		string savePath = GetSavePath();
		if(File.Exists(savePath)) {
			string json = File.ReadAllText(savePath);
			Debug.Log("Loaded json: " + json);
			MazeProgressSave mazeProgressSave = JsonUtility.FromJson<MazeProgressSave>(json);
			this.mazeProgressModel = new MazeProgressModel(mazeProgressSave.currentProgress);
			Debug.Log("maze progress save current progress: " + this.mazeProgressModel.currentProgress.ToString());
		}
	}

	private void SynchRecordToJsonFile() {
		this.InitDirectories();
		var mazeProgressSave = new MazeProgressSave(this.mazeProgressModel.currentProgress);
		string json = JsonUtility.ToJson(
			mazeProgressSave,
			true
		);
		Debug.Log("SynchRecordsToJsonFile filepath: " + this.GetSavePath());
		Debug.Log("SynchRecordsToJsonFile json: " + json);
		File.WriteAllText(this.GetSavePath(), json, Encoding.UTF8);
	}

	private string GetSaveDirPath() {
		return Application.persistentDataPath + SAVE_DIR;
	}

	private string GetSavePath() {
		return Application.persistentDataPath + SAVE_DIR + SAVE_FILE;
	}


}
