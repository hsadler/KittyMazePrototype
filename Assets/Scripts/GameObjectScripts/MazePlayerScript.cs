using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerScript : MonoBehaviour {


	public SpriteRenderer kittyThumbSprite;

	
	void Start() {
		var kittyModel = KittyService.GetSelected();
		Sprite sprite = AssetService.GetSprite(kittyModel.thumbAssetAddress);
		kittyThumbSprite.sprite = sprite;
	}

	void Update() {}


}
