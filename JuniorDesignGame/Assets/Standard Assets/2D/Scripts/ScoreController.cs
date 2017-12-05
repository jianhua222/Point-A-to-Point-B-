using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreController : MonoBehaviour {

	public int playerScore;        //This is the player's score.
	public int pScore = 10;
    
	public Text scoreText;


	// Use this for initialization
	void Start () {
		playerScore = GameControl.control.score;
		UpdateScore ();
        
	}
	
	// Update is called once per frame
	void Update () {
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + playerScore.ToString();

    }

    public void increaseScore(int x)
    {
        playerScore += x;
        UpdateScore();
        GameControl.control.score = playerScore;
    }
}
