using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittySelectScrollListScript : MonoBehaviour {


	public GameObject scrollContent;
	public GameObject kittyScrollContentItemPrefab;


	// UNITY HOOKS

	void Start() {
		List<KittyModel> kitties = KittyService.GetAll();
		foreach (var kittyModel in kitties) {
			if(kittyModel.isUnlocked) {
				GameObject kittyScrollContentItem = Instantiate(
					kittyScrollContentItemPrefab, 
					scrollContent.transform
				);
				Sprite sprite = AssetService.GetSprite(kittyModel.thumbAssetAddress);
				var script = kittyScrollContentItem.GetComponent<KittyScrollContentItemScript>();
				script.kittyImage.sprite = sprite;
				script.kittyModel = kittyModel;
			}
		}
	}

	void Update() {}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS


}
