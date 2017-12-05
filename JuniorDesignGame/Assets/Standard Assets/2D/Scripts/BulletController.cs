using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    GameObject player;
    Experience exp;
    GameObject manager;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        exp = player.GetComponent<Experience>();
        manager = GameObject.Find("_Manager");

    }

    // Update is called once per frame
    void Update () {
        checkBulletLocation();
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().takeDamage(1);
            //Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }

    void checkBulletLocation()
    {
        //bounds check
        if(gameObject.transform.position.x < Camera.main.transform.position.x -20 || gameObject.transform.position.x > Camera.main.transform.position.x + 20
            || gameObject.transform.position.y < Camera.main.transform.position.y -20 || gameObject.transform.position.y > Camera.main.transform.position.y + 20)
        {
            Destroy(gameObject);
        }
    }
}
