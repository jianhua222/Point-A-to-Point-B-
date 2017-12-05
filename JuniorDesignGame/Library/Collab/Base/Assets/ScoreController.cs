using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	public int playerScore;        //This is the player's score.
	public int pScore = 10;

	public GUIText scoreText;

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + playerScore);
	}

	//COLLISIONS
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			playerScore -= pScore;
			UpdateScore ();
		}
	}

	// Use this for initialization
	void Start () {
		playerScore = 10000;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + playerScore;
	}
}
