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

		// search Resources directory for "Kitty" assets
		List<Sprite> kittySprites =
			Resources.LoadAll("Kitty", typeof(Sprite))
			.Cast<Sprite>()
			.ToList();
		List<Sprite> kittyThumbSprites =
			Resources.LoadAll("KittyThumb", typeof(Sprite))
			.Cast<Sprite>()
			.ToList();
		var kittiesToSave = new List<KittyModel>();
		foreach (var kittySprite in kittySprites) {
			// create kitty model if it doesn't yet exist
			var kittyModel = KittyService.GetKittyByAssetName(kittySprite.name);
			if(kittyModel == null) {
				kittyModel = new KittyModel(
					"none",
					kittySprite.name,
					KittyService.GetFormattedKittyAssetAddress(kittySprite.name),
					KittyService.GetFormattedKittyThumbAssetAddress(kittySprite.name),
					false,
					false
				);
				kittiesToSave.Add(kittyModel);
			}
			// register assets
			AssetService.SetSprite(
				KittyService.GetFormattedKittyAssetAddress(kittySprite.name),
				kittySprite
			);
		}
		foreach(var kittyThumbSprite in kittyThumbSprites) {
			// register assets
			string thumbAddress = KittyService.GetFormattedKittyThumbAssetAddress(
				kittyThumbSprite.name,
				true
			);
			AssetService.SetSprite(
				thumbAddress,
				kittyThumbSprite
			);
		}
		// if any assets do not yet exist as records in the
		// datastore, insert them with a default state
		KittyService.SaveKitties(kittiesToSave);

		// TODO: accessories startup processes

	}

	// IMPLEMENTATION METHODS


}
