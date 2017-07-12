using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.black;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onMouseEnter () {
		GetComponent<Renderer>().material.color = Color.red;

	}

	void onMouseExit () {
		GetComponent<Renderer>().material.color = Color.black;
	}
}
