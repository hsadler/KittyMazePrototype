﻿using System.Collections;
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

		// TODO: accessories startup processes
		foreach(string accessoryGroup in AccessoryService.accessoryGroups) {
			foreach(string accessorySubGroup in AccessoryService.accessorySubGroups) {
				string address = AccessoryService.GetFormattedAssetDirectory(
					accessoryGroup, 
					accessorySubGroup
				);
				List<Sprite> accessorySprites = Resources.LoadAll(address, typeof(Sprite))
					.Cast<Sprite>()
					.ToList();
				Debug.Log("count accessory sprites: " + accessorySprites.Count.ToString());
			}
		}
			// - for each accessory type
			// - for each letter named directory

	}

	// IMPLEMENTATION METHODS


}
