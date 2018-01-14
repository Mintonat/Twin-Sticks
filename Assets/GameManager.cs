using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;

	private bool paused = false;
	private float fixedDeltaTime;

	void Start (){
		fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			recording = false;
		} else {
			recording = true;
		}
		if (CrossPlatformInputManager.GetButtonUp ("Pause") && !paused) {
			PauseGame ();
			paused = true;
		}else if (CrossPlatformInputManager.GetButtonUp ("Pause") && paused) {
			ResumedGame ();
			paused = false;
		}
	}
	void PauseGame(){
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}
	void ResumedGame(){
		Time.timeScale = 1f;
		Time.fixedDeltaTime = fixedDeltaTime;
	}
}
