using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour {

	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;

	public SpriteRenderer sr;


	// Use this for initialization
	void Start () {
		// Calcul des angles avec conversion du monde de la camera au monde du pixel
		leftBottomCameraBorder  = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		leftTopCameraBorder     = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightTopCameraBorder    = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
			Calcul de la taille du sprite auquel est attaché
			Taille normal = GameObject.GetComponent<SpriteRenderer>().bounds.size
			On prend en compte les éventuelles transformations demandés lors de l'integration du
			siz vaut alors la taille normale * par la défrmations (notemment le zoom)
		*/
		siz.x = sr.bounds.size.x;
		siz.y = sr.bounds.size.y;

		/*
			Positionnement du vaisseau contre le bord gauche de l'écran
		*/

//		sr.transform.position = new Vector3 (
//			leftTopCameraBorder.x+ (siz.x /2),
//			transform.position.y,
//			transform.position.z);

		/*
			Si la position en Y de notre vaisseau est inférieur à la limite basse de l'écran on repositionne
			le vaisseau en bas de l'écran
		*/

		if (transform.position.y < leftBottomCameraBorder.y+(siz.y /2)){
			sr.transform.position = new Vector3(
				transform.position.x,
				leftBottomCameraBorder.y+ (siz.y/2),
				transform.position.z);

		}

		/*
			Si la position en Y de notre vaisseau est supérieur à la limite haute de l'écran on repositionne
			le vaisseau en haut de l'écran
		*/

		if (transform.position.y > rightTopCameraBorder.y+(siz.y/2)){
					sr.transform.position = new Vector3(
						transform.position.x,
						leftTopCameraBorder.y+(siz.y/2),
						transform.position.z);
		
				}




		/*
			Si la position en X de notre vaisseau est inférieur à la limite gauche de l'écran on repositionne
			le vaisseau à gauche de l'écran
		*/

		if (transform.position.x < leftTopCameraBorder.x+(siz.x /2)){
			sr.transform.position = new Vector3(
				leftTopCameraBorder.x+(siz.x/2),
				transform.position.y,
				transform.position.z);

		}

		/*
			Si la position en X de notre vaisseau est supérieur à la limite droite de l'écran on repositionne
			le vaisseau à droite de l'écran
		*/

		if (transform.position.x > rightBottomCameraBorder.x+(siz.x/2)){
			sr.transform.position = new Vector3(
				rightBottomCameraBorder.x+(siz.x/2),
				transform.position.y,
				transform.position.z);

		}
	}
}
