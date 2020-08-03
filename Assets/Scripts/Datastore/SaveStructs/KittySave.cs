using System.Collections.Generic;

[System.Serializable]
public struct KittySave {

	// SAVE STRUCT FOR KITTY DATA


	public List<KittyModel> models;


	public KittySave(List<KittyModel> models) {
		this.models = models;
	}


}
