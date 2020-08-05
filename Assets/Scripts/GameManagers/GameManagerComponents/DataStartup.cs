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
			var kittyModel = KittyService.GetModelByAssetName(kittySprite.name);
			if(kittyModel == null) {
				kittyModel = new KittyModel(
					"none",
					kittySprite.name,
					KittyService.GetFormattedAssetAddress(kittySprite.name),
					KittyService.GetFormattedThumbAssetAddress(kittySprite.name),
					false,
					false
				);
				kittiesToSave.Add(kittyModel);
			}
			// register assets
			AssetService.SetSprite(
				KittyService.GetFormattedAssetAddress(kittySprite.name),
				kittySprite
			);
		}
		foreach(var kittyThumbSprite in kittyThumbSprites) {
			// register assets
			string thumbAddress = KittyService.GetFormattedThumbAssetAddress(
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
		KittyService.SaveMultiple(kittiesToSave);

		// WORKING HERE...

		// accessories startup processes
		foreach(string accessoryGroup in AccessoryService.accessoryGroups) {
			foreach(string accessorySubGroup in AccessoryService.accessorySubGroups) {

				string addressDir = AccessoryService.GetFormattedAssetDirectory(
					accessoryGroup,
					accessorySubGroup
				);
				List<Sprite> accessorySprites =
					Resources.LoadAll(addressDir, typeof(Sprite))
					.Cast<Sprite>()
					.ToList();
				Debug.Log(
					"count accessory sprites: " +
					accessorySprites.Count.ToString()
				);

				// create accessory models if they don't yet exist
				foreach(Sprite accessorySprite in accessorySprites) {
					// create kitty model if it doesn't yet exist
					var accessoryModel = AccessoryService.GetModelByAssetName(
						accessorySprite.name
					);
					if(accessoryModel == null) {
						accessoryModel = AccessoryModel(
							"none",
							accessorySprite.name,
							AccessoryService.GetFormattedAssetAddress(
								accessoryGroup,
								accessorySubgroup,
								accessorySprite.name
							),
							AccessoryService.GetFormattedThumbAssetAddress(
								accessoryGroup,
								accessorySubgroup,
								accessorySprite.name
							),
							accessoryGroup,
							accessorySubGroup,
							false,
							false
						);
					}
				}

			}
		}
	}

	// IMPLEMENTATION METHODS


}
