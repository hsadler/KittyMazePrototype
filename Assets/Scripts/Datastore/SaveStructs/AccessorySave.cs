using System.Collections.Generic;

[System.Serializable]
public struct AccessorySave {

	// SAVE STRUCT FOR ACCESSORY DATA


	public List<AccessoryModel> models;


	public AccessorySave(List<AccessoryModel> models) {
		this.models = models;
	}


}
