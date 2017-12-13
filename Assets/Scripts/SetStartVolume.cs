using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;


	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			//Debug.Log ("Found Music Manager" + musicManager);
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume (volume);
		} else {
			Debug.LogWarning ("No music manager found in Start Scene. Cannot set initial volume.");

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
