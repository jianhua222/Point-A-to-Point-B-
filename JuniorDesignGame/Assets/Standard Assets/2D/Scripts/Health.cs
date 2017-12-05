using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
    EnemySpawner spawner;
    GameObject man;
    GameObject player;
    ScoreController scoreController;
	// Use this for initialization
	void Start () {
        man = GameObject.Find("_Manager");
        spawner = man.GetComponent<EnemySpawner>();
        player = GameObject.Find("PlayerCharacter");
        scoreController = player.GetComponent<ScoreController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(int amount)
    {
        health -= amount;
        checkDeath();
    }

    void checkDeath()
    {
        if (health <= 0)
        {
            player.GetComponent<Experience>().gainEXP(1);
            scoreController.increaseScore(10);
            if(gameObject.GetComponent<Boss>() != null)
            {
                spawner.bossDied();
            }
            spawner.enemyDiedToBullet(gameObject);
        }
    }


}
