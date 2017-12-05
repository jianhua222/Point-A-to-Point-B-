using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    PlayerHealth playerHealth;
    GameObject player;
    GameObject manager;
    EnemySpawner spawner;
    Experience exp;
    Rigidbody2D rb;
    
    // Use this for initialization
    void Start () {
        player = this.gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
        manager = GameObject.Find("_Manager");
        spawner = manager.GetComponent<EnemySpawner>();
        exp = player.GetComponent<Experience>();
        rb = player.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Nothing interesting");
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log(other.gameObject.name);
            if (!playerHealth.getDamaged())
            {
                playerHealth.TakeDamage(other.gameObject.GetComponent<Enemy>().damage);
                Vector2 helper = player.transform.position - other.gameObject.transform.position;
                rb.AddForce(helper * 10);
                other.gameObject.GetComponentInChildren<enemyMovementController>().flipFacing();
                exp.updateText();
            }
        }
    }
}
