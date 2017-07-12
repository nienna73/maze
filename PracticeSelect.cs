using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PracticeSelect : MonoBehaviour {
	private Button practice;



	// Use this for initialization
	void Start () {

		practice = GetComponent<Button> () ;
		
	}
	
	// Update is called once per frame
	void Update () {

		practice.onClick.AddListener (delegate { loadPractice (); } );
	
	}

	public void btnClick(){
		loadPractice ();
	}
		

	public void loadPractice() {
		SceneManager.LoadScene ("Practice");
	}
}
