using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveAsteroid : MonoBehaviour {

	private Vector3 leftTopCameraBorder;
	private Vector3 siz;

	public float speed;

	private Rigidbody2D rb;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		// Calcul des angles avec conversion du monde de la camera au monde du pixel
		leftTopCameraBorder     = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));

		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2 (-3f, 0f);
		rb.velocity = movement*speed;

		siz.x = sr.bounds.size.x;
		siz.y = sr.bounds.size.y;


		if (transform.position.x < leftTopCameraBorder.x - (siz.x/2)){
			Destroy(gameObject);
		}
		
	}

	void OnDestroy(){
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "myShip") {
			if (GameObject.FindGameObjectWithTag ("life5")) {
				GameObject.FindGameObjectWithTag ("life5").AddComponent<fadeOut> ();
			} else if (GameObject.FindGameObjectWithTag ("life4")) {
				GameObject.FindGameObjectWithTag ("life4").AddComponent<fadeOut> ();
			} else if (GameObject.FindGameObjectWithTag ("life3")) {
				GameObject.FindGameObjectWithTag ("life3").AddComponent<fadeOut> ();
			} else if (GameObject.FindGameObjectWithTag ("life2")) {
				GameObject.FindGameObjectWithTag ("life2").AddComponent<fadeOut> ();
			} else if (GameObject.FindGameObjectWithTag ("life1")) {
				GameObject.FindGameObjectWithTag ("life1").AddComponent<fadeOut> ();
			}
			else if (GameObject.FindGameObjectWithTag("life1") == null){
				explode.instance.explodeNow ();
				Destroy (collider.gameObject);	
				SoundState.instance.shipDeathSound ();
				GameState.instance.goForRoutine ();
//				new WaitForSeconds(5);
//				SceneManager.LoadScene ("gameOver");
			}
		}
	}
}
//rightTopCameraBorder.x+(siz.x/2)