using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {
    PlayerHealth health;
    GameObject player;
    Experience exp;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerCharacter");
        health = player.GetComponent<PlayerHealth>();
        exp = player.GetComponent<Experience>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnCollisionEnter2D(Collision2D col)
    {
        //on collision with player increase health
        if (col.gameObject.tag == "Player")
        {
            health.TakeDamage(-25); // negative damage is healing
            exp.updateText();
            Destroy(gameObject);
        }
    }
}
