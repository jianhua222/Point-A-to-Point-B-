using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeftScript : MonoBehaviour {

    public int speed;
    private Vector3 movement;
    private Vector3 helper;

	// Use this for initialization
	void Start () {
        movement = new Vector3(-.1f * speed,0);
        helper = movement;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 0)
        {
            movement = new Vector3(0, 0, 0);
        }
        else
        {
            movement = helper;
            movement = movement * Time.timeScale;
        }
        transform.position += movement;
    }
}
