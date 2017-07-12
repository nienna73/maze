using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour {

	private Button exit;

	// Use this for initialization
	void Start () {

		exit = GetComponent<Button> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		exit.onClick.AddListener (delegate { exitToMain (); } );
		
	}

	public void btnClick(){
		
		exitToMain ();

	}

	void exitToMain(){
		SceneManager.LoadScene ("MainMenu");
	}
}
