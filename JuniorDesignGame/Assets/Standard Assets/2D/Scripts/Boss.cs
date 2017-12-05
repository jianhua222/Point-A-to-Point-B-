using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    bool goRight;
    //Rigidbody2D rb;
    Transform player;
    //public Vector2 sprint;
    enemyMovementController con;
    float chargeTimeHelper;
    float time;
    //A couple variables for the boss charge
    public float chargeTime;
    //public float chargeSpeed;
    public float chargeCooldownTime;
    //bool cooldown;
    float flipTimeHelper;

	// Use this for initialization
	void Start () {
        //goRight = gameObject.GetComponent<enemyMovementController>().GoRight();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        con = gameObject.GetComponent<enemyMovementController>();
        player = GameObject.Find("PlayerCharacter").transform;
        chargeTimeHelper = 2.0f;
        time = 0;
        //cooldown = false;
        flipTimeHelper = 2;
    }
	
	// Update is called once per frame
	void Update () {
        //Raycast for boss charge
        RaycastHit2D anotherHit = Physics2D.Raycast(transform.position, con.GoRight() ? new Vector2(1, 0) : new Vector2(-1, 0), 7.0f);
        if (anotherHit.collider != null)
        {
            if (anotherHit.collider.gameObject.tag == "Player")
            { 
                charge();
            }
        }

        if (Time.time >= time)
        {
            //Change directions to chase after the player
            if (player.position.x < gameObject.transform.position.x && con.GoRight())
            {
                //Debug.Log("Boss Flip Left");
                con.flipFacing();
                time = Time.time + flipTimeHelper;
            }
            if(player.position.x > gameObject.transform.position.x && !con.GoRight())
            {
                //Debug.Log("Boss Flip Right");
                con.flipFacing();
                time = Time.time + flipTimeHelper;
            }
        }
    }


    void charge()
    {
        if (chargeTimeHelper <= Time.time)
        {
            con.Charge(1.5f);
            chargeTimeHelper = chargeCooldownTime + Time.time;
            //Debug.Log("Charge");
        }
    }

    void endCharge()
    {
        con.ChargeReset();
    }

    public void tired()
    {
        //cooldown = true;
        con.Charge(0.7f);
        chargeTimeHelper = chargeCooldownTime + Time.time + chargeTime;
    }




}
