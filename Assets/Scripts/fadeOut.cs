using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color cl = sr.color;
		cl.a -= 0.51f;
		sr.color = cl;
		if (cl.a < 0) {
			Destroy (gameObject);
		}
	}
}
