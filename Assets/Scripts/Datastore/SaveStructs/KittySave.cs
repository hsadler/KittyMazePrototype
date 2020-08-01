using System.Collections.Generic;

[System.Serializable]
public struct KittySave {

	// SAVE STRUCT FOR KITTY DATA


	public List<KittyModel> kittyModels;  


	public KittySave(List<KittyModel> kittyModels) {
		this.kittyModels = kittyModels;
	}
	

}
