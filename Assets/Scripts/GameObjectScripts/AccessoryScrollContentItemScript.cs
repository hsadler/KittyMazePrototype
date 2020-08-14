﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryScrollContentItemScript : MonoBehaviour {
	
	
	public Image accessoryImage;
	public KittyModel kittyModel;
	public AccessoryModel accessoryModel;

	
	void Start() {}

	void Update() {}

	public void SelectAccessory() {
		AccessoryService.SetSelectedAccessoryForKitty(kittyModel, accessoryModel);
		GameManager.instance.unityEvents.accessorySelectEvent.Invoke();
	}


}
