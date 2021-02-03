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

	private IDictionary<string, Image> headLookup;
	private IDictionary<string, Image> bodyLookup;
	private IDictionary<string, Image> feetLookup;
	private IDictionary<string, Image> tailLookup;
	private IDictionary<string, IDictionary<string, Image>> displayLookup;


	// UNITY HOOKS

	public void Awake() {
		// data structure setup
		this.headLookup = new Dictionary<string, Image>()
		{
			{"L1", this.headL1},
			{"M1", this.headM1},
			{"N1", this.headN1}
		};
		this.bodyLookup = new Dictionary<string, Image>()
		{
			{"L1", this.bodyL1},
			{"M1", this.bodyM1},
			{"N1", this.bodyN1}
		};
		this.feetLookup = new Dictionary<string, Image>()
		{
			{"L1", this.feetL1},
			{"M1", this.feetM1},
			{"N1", this.feetN1}
		};
		this.tailLookup = new Dictionary<string, Image>()
		{
			{"L1", this.tailL1},
			{"M1", this.tailM1},
			{"N1", this.tailN1}
		};
		this.displayLookup = new Dictionary<string, IDictionary<string, Image>>();
		this.displayLookup.Add("Head", this.headLookup);
		this.displayLookup.Add("Body", this.bodyLookup);
		this.displayLookup.Add("Feet", this.feetLookup);
		this.displayLookup.Add("Tail", this.tailLookup);
	}

	public void Start() {
		this.FetchKittyImage();
		GameManager.instance.unityEvents.kittySelectEvent.AddListener(this.FetchKittyImage);
		this.FetchAccessoryImages();
		GameManager.instance.unityEvents.kittySelectEvent.AddListener(this.FetchAccessoryImages);
		GameManager.instance.unityEvents.accessorySelectEvent.AddListener(this.FetchAccessoryImages);
	}

	public void Update() {}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void FetchKittyImage() {
		KittyModel kittyModel = KittyService.GetSelected();
		Sprite kittySprite = AssetService.GetSprite(kittyModel.primaryAssetAddress);
		kittyImage.sprite = kittySprite;
	}

	private void FetchAccessoryImages() {
		// deactivate all accessory game objects
		foreach(var partDict in this.displayLookup.Values) {
			foreach(var image in partDict.Values) {
				image.gameObject.SetActive(false);
			}
		}
		// TODO: implementation of this method is unoptimized, utilize lookup batching in a future refactor 
		KittyModel kittyModel = KittyService.GetSelected();
		foreach(var kittyAccessoryModel in KittyAccessoryService.GetModelsByKittyId(kittyModel.id)) {
			if(kittyAccessoryModel.isSelected) {
				// lookup accessory model
				var accessoryModel = AccessoryService.GetModelsByIds(new List<string> {kittyAccessoryModel.accessoryId})[0];
				// lookup sprite
				Sprite accessorySprite = AssetService.GetSprite(accessoryModel.primaryAssetAddress);
				// lookup display object image and assign sprite
				Image displayImage = this.displayLookup[kittyAccessoryModel.accessoryGroup][kittyAccessoryModel.accessorySubGroup];
				displayImage.sprite = accessorySprite;
				displayImage.gameObject.SetActive(true);
			}
		} 
	}


}
