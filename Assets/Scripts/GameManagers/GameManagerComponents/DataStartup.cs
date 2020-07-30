using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataStartup {

	// RESPONSIBLE FOR DATA STARTUP PROCESSES


	public DataStartup() {}

	// INTERFACE METHODS

	public void ExecuteStartupProcesses() {
		// STUB
		// search Resources directory for assets
		List<Sprite> kittySprites =
			Resources.LoadAll("Kitty", typeof(Sprite))
			.Cast<Sprite>()
			.ToList();
		foreach (var kittySprite in kittySprites) {
			// register assets
			GameManager.instance.assets.SetSprite(
				kittySprite.name,
				kittySprite
			);
			// if any assets do not yet exist as records in the
			// datastore, insert them with a default state
			var kittyModel = Kitty.GetKittyByAssetName(kittySprite.name);
			if(kittyModel == null) {
				Debug.Log("no kitty model found");
			}
		}
	}

	// IMPLEMENTATION METHODS


}
