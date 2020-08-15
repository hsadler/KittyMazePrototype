using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectScrollListScript : MonoBehaviour {
	
	
	public GameObject scrollContent;
	public GameObject accessoryScrollContentItemPrefab;

	private List<GameObject> accessoryItems = new List<GameObject>();


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
		// clear the exising accessory items in the scroll list
		foreach(var accessoryItem in this.accessoryItems) {
			GameObject.Destroy(accessoryItem);
		}
		this.accessoryItems.Clear();
		List<AccessoryModel> accessories = AccessoryService.GetAll();
		foreach (var accessoryModel in accessories) {
			// TODO: in the future, only display unlocked accessories per currenlty selected kitty
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
			script.kittyModel = KittyService.GetSelected();
			script.accessoryModel = accessoryModel;
			this.accessoryItems.Add(accessoryScrollContentItem);
		}
	}


}
