using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 mouvement = new Vector2 (moveHorizontal, moveVertical);

		if (Input.GetKey ("down")) {
			rb.transform.rotation = Quaternion.Euler(0, 0, -25);
		}

		else if (Input.GetKey ("up")) {
			rb.transform.rotation = Quaternion.Euler(0,0,25);

		}
		else
			rb.transform.rotation = Quaternion.Euler(0,0,0);

		rb.velocity = mouvement*speed;
	}
}
