using System.Collections.Generic;

[System.Serializable]
public struct KittyAccessorySave {

	// SAVE STRUCT FOR KITTY-ACCESSORY DATA


	public List<KittyAccessoryModel> models;


	public KittyAccessorySave(List<KittyAccessoryModel> models) {
		this.models = models;
	}


}
