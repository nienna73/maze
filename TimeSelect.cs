using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeSelect : MonoBehaviour {
	private Button timed;



	// Use this for initialization
	void Start () {

		timed = GetComponent<Button> () ;
		
	}
	
	// Update is called once per frame
	void Update () {

		timed.onClick.AddListener (delegate { loadTimed (); } );
	
	}

	public void btnClick(){
		loadTimed ();
	}
		

	public void loadTimed() {
		SceneManager.LoadScene ("Timed");
	}
}
