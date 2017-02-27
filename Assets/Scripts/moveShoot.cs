using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour {

	private Vector3 rightTopCameraBorder;
//	private Vector3 leftTopCameraBorder;
//	private Vector3 rightBottomCameraBorder;
//	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
//	private float angle;

	public float speed;

	private Rigidbody2D rb;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {

//		leftBottomCameraBorder  = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
//		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
//		leftTopCameraBorder     = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightTopCameraBorder    = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
//		angle = 1;

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2 (3f, 0f);
		speed = 8;
		rb.velocity = movement*speed;

		siz.x = sr.bounds.size.x;
		siz.y = sr.bounds.size.y;


		if (transform.position.x > rightTopCameraBorder.x - (siz.x/2))
			Destroy(gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (GameObject.FindGameObjectWithTag ("asteroid")) {
			collider.gameObject.AddComponent<fadeOut>();
			Destroy (gameObject);
			GameState.instance.addScorePlayer (1);
		}

	}
}
