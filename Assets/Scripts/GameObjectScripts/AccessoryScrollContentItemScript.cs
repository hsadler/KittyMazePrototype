using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryScrollContentItemScript : MonoBehaviour {
	
	
	public Image accessoryImage;
	public KittyModel kittyModel;
	public AccessoryModel accessoryModel;

	
	// UNITY HOOKS

	void Start() {}

	void Update() {}

	// INTERFACE METHODS

	public void SelectAccessory() {
		AccessoryService.ToggleSelectedAccessoryForKitty(kittyModel, accessoryModel);
		GameManager.instance.unityEvents.accessorySelectEvent.Invoke();
	}

	// IMPLEMENTATION METHODS


}
