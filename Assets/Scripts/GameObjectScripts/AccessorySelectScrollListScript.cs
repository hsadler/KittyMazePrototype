using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectScrollListScript : MonoBehaviour {
	
	
	public GameObject scrollContent;
	public GameObject accessoryScrollContentItemPrefab;


	void Start() {
		List<AccessoryModel> accessories = AccessoryService.GetAll();
		foreach (var accessoryModel in accessories) {
			// TODO: in the future, only display unlocked accessories per currenlty selected kitty
			GameObject accessoryScrollContentItem = Instantiate(
				accessoryScrollContentItemPrefab, 
				scrollContent.transform
			);
			Sprite sprite = AssetService.GetSprite(accessoryModel.thumbAssetAddress);
			if(sprite != null) {
				accessoryScrollContentItem.GetComponent<AccessoryScrollContentItemScript>()
					.accessoryImage
					.sprite = sprite;
			} else {
				Debug.Log("Sprite not found at address: " + accessoryModel.thumbAssetAddress);
			}
		}
	}

	void Update() {}


}
