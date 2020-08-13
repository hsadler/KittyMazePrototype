using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyScript : MonoBehaviour {


	public Image kittyImage;


	// UNITY HOOKS

	void Start() {
		this.FetchKittyImage();
	}

	void Update() {}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void FetchKittyImage() {
		KittyModel kittyModel = KittyService.GetSelected();
		Sprite kittySprite = AssetService.GetSprite(kittyModel.primaryAssetAddress);
		kittyImage.sprite = kittySprite;
	}


}
