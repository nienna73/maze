using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class InfiniteSelect : MonoBehaviour {
	private Button infinite;



	// Use this for initialization
	void Start () {

		infinite = GetComponent<Button> () ;
		
	}
	
	// Update is called once per frame
	void Update () {

		infinite.onClick.AddListener (delegate { loadInfinite (); } );
	
	}

	public void btnClick(){
		loadInfinite ();
	}
		

	public void loadInfinite() {
		SceneManager.LoadScene ("Infinite");
	}
}
