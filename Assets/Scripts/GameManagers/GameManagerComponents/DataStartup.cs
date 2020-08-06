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

		// kitty startup processes
		List<Sprite> kittySprites =
			Resources.LoadAll("Kitty", typeof(Sprite))
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
		// save thumb kitty sprites to Asset service
		List<Sprite> kittyThumbSprites =
			Resources.LoadAll("KittyThumb", typeof(Sprite))
			.Cast<Sprite>()
			.ToList();
		foreach(var kittyThumbSprite in kittyThumbSprites) {
			string thumbAddress = KittyService.GetFormattedThumbAssetAddress(
				kittyThumbSprite.name,
				true
			);
			AssetService.SetSprite(
				thumbAddress,
				kittyThumbSprite
			);
		}
		// insert kitties to be saved
		KittyService.SaveMultiple(kittiesToSave);

		// accessories startup processes
		var accessoriesToSave = new List<AccessoryModel>();
		foreach(string accessoryGroup in AccessoryService.accessoryGroups) {
			foreach(string accessorySubGroup in AccessoryService.accessorySubGroups) {
				// load accessory sprites from Resources
				string addressDir = AccessoryService.GetFormattedAssetDirectory(
					accessoryGroup,
					accessorySubGroup
				);
				List<Sprite> accessorySprites =
					Resources.LoadAll(addressDir, typeof(Sprite))
					.Cast<Sprite>()
					.ToList();
				// Debug.Log("count accessory sprites: " + accessorySprites.Count.ToString());
				foreach(Sprite accessorySprite in accessorySprites) {
					// create accessory models if they don't yet exist
					var accessoryModel = AccessoryService.GetModelByAssetName(
						accessorySprite.name
					);
					if(accessoryModel == null) {
						accessoryModel = new AccessoryModel(
							"none",
							accessorySprite.name,
							AccessoryService.GetFormattedAssetAddress(
								accessoryGroup,
								accessorySubGroup,
								accessorySprite.name
							),
							AccessoryService.GetFormattedThumbAssetAddress(
								accessoryGroup,
								accessorySubGroup,
								accessorySprite.name
							),
							accessoryGroup,
							accessorySubGroup
						);
						accessoriesToSave.Add(accessoryModel);
					}
					// register assets
					AssetService.SetSprite(
						AccessoryService.GetFormattedAssetAddress(
							accessoryGroup,
							accessorySubGroup,
							accessorySprite.name
						),
						accessorySprite
					);
				}
				// save thumb accessory sprites to Asset service
				string thumbAddressDir = AccessoryService.GetFormattedThumbAssetDir(
					accessoryGroup,
					accessorySubGroup
				);
				List<Sprite> accessoryThumbSprites =
					Resources.LoadAll(thumbAddressDir, typeof(Sprite))
					.Cast<Sprite>()
					.ToList();
				foreach(var accessoryThumbSprite in accessoryThumbSprites) {
					string thumbAddress = AccessoryService.GetFormattedThumbAssetAddress(
						accessoryGroup,
						accessorySubGroup,
						accessoryThumbSprite.name,
						true
					);
					AssetService.SetSprite(
						thumbAddress,
						accessoryThumbSprite
					);
				}
			}
		}
		// insert accessories to be saved
		AccessoryService.SaveMultiple(accessoriesToSave);

		// TODO: 
		// kitty-accessory startup processes
		// var kittyModels = KittyService.GetAll();
		// var accessoryModels = AccessoryService.GetAll();

	}

	// IMPLEMENTATION METHODS


}
