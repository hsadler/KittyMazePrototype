using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectScrollListScript : MonoBehaviour {
	
	
	public GameObject scrollContent;
	public GameObject accessoryScrollContentItemPrefab;

	private List<GameObject> accessoryItems = new List<GameObject>();

	private const bool VIEW_ALL_ACCESSORIES = true;


	// UNITY HOOKS

	void Start() {
		this.RenderAccessoryItems();
	}

	void Update() {}

	void OnEnable() {
		this.RenderAccessoryItems();
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void RenderAccessoryItems() {
		var selectedKittyModel = KittyService.GetSelected();
		// clear the exising accessory items in the scroll list
		foreach(var accessoryItem in this.accessoryItems) {
			GameObject.Destroy(accessoryItem);
		}
		this.accessoryItems.Clear();
		// setup kitty-accessory models for lookups
		var accessoryIdToKittyAccessoryModel = new Dictionary<string, KittyAccessoryModel>();
		foreach(var kittyAccessoryModel in KittyAccessoryService.GetModelsByKittyId(selectedKittyModel.id)) {
			accessoryIdToKittyAccessoryModel.Add(kittyAccessoryModel.accessoryId, kittyAccessoryModel);
		}
		List<AccessoryModel> accessories = AccessoryService.GetAll();
		foreach (var accessoryModel in accessories) {
			var kittyAccessoryModel = accessoryIdToKittyAccessoryModel[accessoryModel.id];
			// create accessory item per unlocked accessory item for currently selected kitty
			if(kittyAccessoryModel.isUnlocked || VIEW_ALL_ACCESSORIES) {
				GameObject accessoryScrollContentItem = Instantiate(
					accessoryScrollContentItemPrefab, 
					scrollContent.transform
				);
				var script = accessoryScrollContentItem.GetComponent<AccessoryScrollContentItemScript>();
				Sprite sprite = AssetService.GetSprite(accessoryModel.thumbAssetAddress);
				if(sprite != null) {
					script.accessoryImage.sprite = sprite;
				} else {
					Debug.Log("Sprite not found at address: " + accessoryModel.thumbAssetAddress);
				}
				script.kittyModel = selectedKittyModel;
				script.accessoryModel = accessoryModel;
				this.accessoryItems.Add(accessoryScrollContentItem);
			}
		}
	}


}
