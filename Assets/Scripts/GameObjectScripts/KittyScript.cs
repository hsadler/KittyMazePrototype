using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyScript : MonoBehaviour {


	public Image kittyImage;
	
	public Image headL1;
	public Image headM1;
	public Image headN1;
	
	public Image bodyL1;
	public Image bodyM1;
	public Image bodyN1;

	public Image feetL1;
	public Image feetM1;
	public Image feetN1;

	public Image tailL1;
	public Image tailM1;
	public Image tailN1;


	// UNITY HOOKS

	void Start() {
		this.FetchKittyImage();
		GameManager.instance.unityEvents.kittySelectEvent.AddListener(this.FetchKittyImage);
		this.FetchAccessoryImages();
		GameManager.instance.unityEvents.accessorySelectEvent.AddListener(this.FetchAccessoryImages);
	}

	void Update() {}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void FetchKittyImage() {
		KittyModel kittyModel = KittyService.GetSelected();
		Sprite kittySprite = AssetService.GetSprite(kittyModel.primaryAssetAddress);
		kittyImage.sprite = kittySprite;
	}

	private void FetchAccessoryImages() {
		print("Fetching accessory images");
	}


}
