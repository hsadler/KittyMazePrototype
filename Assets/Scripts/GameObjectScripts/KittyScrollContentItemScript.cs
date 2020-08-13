using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyScrollContentItemScript : MonoBehaviour {


	public Image kittyImage;
	public KittyModel kittyModel;

	
	void Start() {}

	void Update() {}

	public void SelectKitty() {
		KittyService.SetSelected(this.kittyModel);
		GameManager.instance.unityEvents.kittySelectEvent.Invoke();
	}


}
