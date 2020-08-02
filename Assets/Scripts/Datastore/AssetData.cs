using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetData {

	// DATA STATE MANAGER FOR ASSETS


	public IDictionary<string, Sprite> spriteRegistry;


	// INTERFACE METHODS

	public AssetData() {
		this.spriteRegistry = new Dictionary<string, Sprite>();
	}


}