using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundState : MonoBehaviour {

	public static SoundState instance;
	public AudioClip playerShotSound;
	public AudioClip PlayerExplode;

	// Use this for initialization
	void Start () {
		instance = this;	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		} else if (this != instance) {
			Destroy (this.gameObject);
		}
	}


	public void touchButtonSound(){
		MakeSound (playerShotSound);
	}

	public void shipDeathSound(){
		MakeSound (PlayerExplode);
	}

	//lancer la lecture d'un son 
	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
