using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectIfAsteroid : MonoBehaviour {

	private GameObject[] respawns;
	private Vector3 siz;
	private Vector3 rightTopCameraBorder;
	private Vector3 rightBottomCameraBorder;

	// Use this for initialization
	void Start () {
	
		rightTopCameraBorder    = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
		rightBottomCameraBorder    = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		//Creation d'un tableau contenant les asteroids present dans la scene
		respawns = GameObject.FindGameObjectsWithTag("asteroid");

		//Si le tableau contient un asteroid, récupère sa taille (le premier)
		if (respawns.Length > 0) {
			siz.x = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.x;
			siz.y = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.y;
		}

		// Le tableau contient moins de 10 asteroids ?
		if (respawns.Length < 10) {
			//Tirage ou non d'un asteroid
			if(Random.Range(1,100) >= 50 || respawns.Length < 4){
				//Creation d'un asteroid avec un y aléatoire
				GameObject gY =Instantiate (Resources.Load("asteroidSp"),
					new Vector3 (
						rightTopCameraBorder.x+(siz.x/2),
						Random.Range (rightTopCameraBorder.y, rightBottomCameraBorder.y),
						transform.position.z),
					Quaternion.identity) as GameObject;
			
			}
		}
	}
}
