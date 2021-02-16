using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

public class DataStartup {

	// RESPONSIBLE FOR DATA STARTUP PROCESSES


	public DataStartup() {}

	// INTERFACE METHODS

	public void ExecuteStartupProcesses() {
		this.KittyStartupProcesses();
		this.AccessoryStartupProcesses();
		this.KittyAccessoryStartupProcesses();
		this.DefautKittySelection();
	}

	// IMPLEMENTATION METHODS

	private void KittyStartupProcesses() {
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
					System.Guid.NewGuid().ToString(),
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
	}

	private void AccessoryStartupProcesses() {
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
							System.Guid.NewGuid().ToString(),
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
				// Debug.Log("count accessory thumb sprites: " + accessoryThumbSprites.Count.ToString());
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
	}

	private void KittyAccessoryStartupProcesses() {
		var kittyModels = KittyService.GetAll();
		var accessoryModels = AccessoryService.GetAll();
		// create the kitty-accessory models if they don't yet exist
		var kittyAccessoriesToSave = new List<KittyAccessoryModel>();
		foreach(var kittyModel in kittyModels) {
			foreach(var accessoryModel in accessoryModels) {
				var kittyAccessoryModel = 
					KittyAccessoryService.GetModelByKittyAndAccessoryCombination(
						kittyModel,
						accessoryModel
					);
				if(kittyAccessoryModel == null) {
					kittyAccessoryModel = new KittyAccessoryModel(
						kittyModel.id,
						accessoryModel.id,
						accessoryModel.accessoryGroup,
						accessoryModel.accessorySubGroup,
						false,
						false
					);
					kittyAccessoriesToSave.Add(kittyAccessoryModel);
				}
			}
		}
		// insert kitty-accessories to be saved
		KittyAccessoryService.SaveMultiple(kittyAccessoriesToSave);
	}

	private void DefautKittySelection() {
		var kitties = KittyService.GetAll();
		bool kittySelected = false;
		KittyModel kittyUnlocked = null;
		foreach(var kitty in kitties) {
			if(kitty.isSelected) {
				kittySelected = true;
			}
			if(kittyUnlocked == null && kitty.isUnlocked) {
				kittyUnlocked = kitty;
			}
		}
		if(!kittySelected) {
			if(kittyUnlocked != null) {
				// set first kitty found that's unlocked to selected status
				kittyUnlocked.isSelected = true;
			} else {
				// set random kitty to unlocked and selected
				int randomKittyIndex = Random.Range(0, kitties.Count);
				var randomKitty = kitties[randomKittyIndex];
				randomKitty.isUnlocked = true;
				randomKitty.isSelected = true;
			}
		}
		KittyService.SaveMultiple(kitties);
	}


}
