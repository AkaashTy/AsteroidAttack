using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public static GameState instance;
	private int scorePlayer;

	// Use this for initialization
	void Start () {
		instance = this;	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		} else if (this != instance) {
			Destroy (this.gameObject);
		}

//		StartCoroutine (changeScene());
	}
		
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("scoreLabel").GetComponent<Text>().text = "" + getScorePlayer();
	}

	public void addScorePlayer(int toAdd){
		scorePlayer += toAdd;
	}

	public int getScorePlayer(){
		return scorePlayer;
	}

	public void goForRoutine(){
		StartCoroutine (changeScene ());
	}

	public IEnumerator changeScene(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("gameOver");
	}
}
