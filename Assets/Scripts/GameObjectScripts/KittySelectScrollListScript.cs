using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittySelectScrollListScript : MonoBehaviour {


	public GameObject scrollContent;
	public GameObject kittyScrollContentItemPrefab;


	void Start() {
		List<KittyModel> kitties = Kitty.GetAllKitties();
		foreach (var kittyModel in kitties) {
			GameObject kittyScrollContentItem = Instantiate(
				kittyScrollContentItemPrefab, 
				scrollContent.transform
			);
			Sprite sprite = GameManager.instance.assets.GetSprite(kittyModel.assetName);
			kittyScrollContentItem.GetComponent<KittyScrollContentItemScript>()
				.kittyImage
				.sprite = sprite;
		}
	}

	void Update() {}


}
