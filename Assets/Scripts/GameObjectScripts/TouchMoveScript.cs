using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveScript : MonoBehaviour {
 
 
	private Rigidbody rb;
	private Vector3 direction;
	private float moveSpeed = 10f;

	
	// UNITY HOOKS

	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		this.CheckTouchMove();
		this.CheckMouseMove();
	}

	// INTERFACE METHODS

	// IMPLEMENTATION METHODS

	private void CheckTouchMove() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
			touchPosition.z = 0;
			direction = touchPosition - transform.position;
			rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
			// if (touch.phase == TouchPhase.Ended) {
			// 	rb.velocity = Vector2.zero;
			// }
		} else {
			rb.velocity = Vector2.zero;
		}
	}

	private void CheckMouseMove() {
		if(Input.GetMouseButton(0)) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = 0;
			direction = mousePosition - transform.position;
			rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
		} else {
			rb.velocity = Vector2.zero;
		}
	}


}