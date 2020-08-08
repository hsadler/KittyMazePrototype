﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittySelectScrollListScript : MonoBehaviour {


	public GameObject scrollContent;
	public GameObject kittyScrollContentItemPrefab;


	void Start() {
		List<KittyModel> kitties = KittyService.GetAll();
		foreach (var kittyModel in kitties) {
			// TODO: in the future, only display unlocked kitties
			GameObject kittyScrollContentItem = Instantiate(
				kittyScrollContentItemPrefab, 
				scrollContent.transform
			);
			Sprite sprite = AssetService.GetSprite(kittyModel.thumbAssetAddress);
			kittyScrollContentItem.GetComponent<KittyScrollContentItemScript>()
				.kittyImage
				.sprite = sprite;
		}
	}

	void Update() {}


}
