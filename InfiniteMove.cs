﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMove : MonoBehaviour {


	private float speed;
	private Rigidbody rb;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
	

	}



	void FixedUpdate () {
		speed = 15.0f;

		// The code below is for PC and key board input

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	

		// The code below is for iPhone tilt input
//
//		Screen.orientation = ScreenOrientation.LandscapeLeft;
//	
//		Vector3 acc = Input.acceleration;
//
//		rb.AddForce (acc.x*speed, 0, acc.y*speed);


	}


	void OnTriggerEnter(Collider other) {

		int xSize;
		Vector3 cameraPos;
		float cameraHeight;
		float cameraHyp;
		float cameraAngle;

		cameraPos = Camera.current.transform.position;
		

		if (other.gameObject.CompareTag("End")) {
			InfiniteMaze.control.Destroy ();
			Destroy (other.gameObject);


			xSize = InfiniteMaze.control.GetxSize ();
			cameraHeight = cameraPos.y;
			cameraHyp = Mathf.Sqrt(((xSize/2) * (xSize/2)) + (cameraHeight * cameraHeight));
			cameraAngle = Mathf.Asin((xSize/2) / cameraHyp);
			cameraAngle = cameraAngle * Mathf.Rad2Deg;
			
			Camera.current.fieldOfView = (30 + cameraAngle);
			Camera.current.transform.Translate(0.5f, 0.5f, -1);
		
			Destroy (this.gameObject);
		}

	

		speed = 0.0f;
	}
		

}