using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerText : MonoBehaviour {

	private float timeLeft = 10.0f;
	private bool isRunning = true;
	private int intTime;

	public Text endText;
	public Text timeText;
	public static TimerText control;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (isRunning) {
			timeLeft -= Time.deltaTime;
			intTime = (int)timeLeft;
			timeText.GetComponent<Text> ().text = intTime.ToString ();
			if (timeLeft <= 0) {
				GameOver ();
				isRunning = false;
				intTime = 0;
			}
		}
		
	}

	void GameOver(){
		endText.GetComponent<Text> ().text = "Time's up!";

	}

	public bool GetRunning(){
		return isRunning;
	}
}
