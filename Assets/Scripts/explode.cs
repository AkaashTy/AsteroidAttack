using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

//	private ParticleSystem ps;
	public GameObject explosion;
	public static explode instance;

	// Use this for initialization
	void Start () {
		instance = this;	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		} else if (this != instance) {
			Destroy (this.gameObject);
		}
//		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void explodeNow(){
		Instantiate (explosion, transform.position, transform.rotation);
			
	}
}
