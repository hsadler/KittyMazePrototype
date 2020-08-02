using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataStartup {

	// RESPONSIBLE FOR DATA STARTUP PROCESSES


	public DataStartup() {}

	// INTERFACE METHODS

	public void ExecuteStartupProcesses() {
		var gm = GameManager.instance;
		// search Resources directory for assets
		List<Sprite> kittySprites =
			Resources.LoadAll("Kitty", typeof(Sprite))
			.Cast<Sprite>()
			.ToList();
		var kittiesToSave = new List<KittyModel>();
		foreach (var kittySprite in kittySprites) {
			// register assets
			gm.assets.SetSprite(
				kittySprite.name,
				kittySprite
			);
			var kittyModel = Kitty.GetKittyByAssetName(kittySprite.name);
			if(kittyModel == null) {
				kittyModel = new KittyModel("none", kittySprite.name, false, false);
				kittiesToSave.Add(kittyModel);
			}
		}
		// if any assets do not yet exist as records in the
		// datastore, insert them with a default state
		Kitty.SaveKitties(kittiesToSave);
	}

	// IMPLEMENTATION METHODS


}
