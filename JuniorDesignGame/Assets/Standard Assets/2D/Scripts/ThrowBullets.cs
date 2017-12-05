using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ThrowBullets : MonoBehaviour {
    GameObject player;
    public GameObject prefab;
    playerController PlatChar;
    float timestamp;
    float resumeTime;


	// Use this for initialization
	void Start () {
        player = this.gameObject;
        PlatChar = player.GetComponent<playerController>();
        timestamp = 0.25f;
        resumeTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.N) || Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (Time.time >= resumeTime)
            {
                createBullet(PlatChar.getFacingRight());
                resumeTime = Time.time + timestamp;
            }
        }
	}

    void createBullet(bool right)
    {
        GameObject newBullet = Instantiate(prefab) as GameObject;
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        if (right)
        {
            newBullet.transform.position = player.transform.position + new Vector3(1.5f, 0, 0);
            rb.AddForce(newBullet.transform.right * 250);
        }
        else
        {
            newBullet.transform.position = player.transform.position + new Vector3(-1.5f,0,0);
            rb.AddForce(newBullet.transform.right * -250);
            newBullet.transform.Rotate(0, 180, 0);
        }
    }
}
