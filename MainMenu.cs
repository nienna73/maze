using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {
	private bool isStart;
	private bool isQuit;
	public Button startButton;


	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		startButton = GetComponent<Button> () ;
		
	}
	
	// Update is called once per frame
	void Update () {
		startButton.onClick.AddListener (delegate { startGame (); } );
	
	}

	public void btnClick(){
		startGame ();
	}
		

	public void startGame() {
		SceneManager.LoadScene ("ModeSelect");
	}
}
