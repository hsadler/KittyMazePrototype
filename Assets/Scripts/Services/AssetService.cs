using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetService {

	// SERVICE FOR KITTIES


    public static void SetSprite(string key, Sprite sprite) {
		GameManager.instance.assetData.spriteRegistry.Add(key, sprite);
	}

	public static Sprite GetSprite(string key) {
		return GameManager.instance.assetData.spriteRegistry[key];
	}


}
