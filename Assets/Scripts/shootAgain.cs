using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAgain : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Vector3 siz;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		siz.x = sr.bounds.size.x;
		siz.y = sr.bounds.size.y;

		//Appui sur la touche espace
		bool sp = Input.GetKeyDown(KeyCode.Space);
		if (sp) {
			//Position du tir a droite du vaisseau

			Vector3 tmpPos=new Vector3(transform.position.x+siz.x,
				transform.position.y,
				transform.position.z);
			//Creation de la préfab pour les tirs

			GameObject gY = Instantiate (Resources.Load ("shootOrange"),
				                tmpPos,
				                Quaternion.identity)as GameObject;

			SoundState.instance.touchButtonSound ();

		}

	}
}
