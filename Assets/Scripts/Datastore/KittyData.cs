using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyData {

	// DATA ACCESSOR FOR KITTY RECORDS


	// TODO: implement
		// - probably needs to be a singleton

	public KittyData() {}

	// INTERFACE METHODS
	
	public List<KittyModel> GetModels() {
		List<KittyModel> kittyModels = new List<KittyModel>();
		return kittyModels;
	}

	public bool SaveModel(KittyModel model) {
		return true;
	}

	// IMPLEMENTATION METHODS
	
	private void LoadRecords() {}

	private void SynchRecordsToJsonFile() {} 
	

}
