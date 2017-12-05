using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Experience : MonoBehaviour {
    int exp;
    int toNextLevel;
    int level;
    GameObject player;
    PlayerHealth health;
    public Text playerLevel;
    //public Text helper;


	// Use this for initialization
	void Start () {
        exp = GameControl.control.experience;
        level = GameControl.control.level;
        toNextLevel = level * 10;
        player = this.gameObject;
        health = player.GetComponent<PlayerHealth>();
        updateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gainEXP(int amount)
    {
        exp += amount;
        checkLevelUp();
        updateText();

    }

    void checkLevelUp()
    {
        if(exp >= toNextLevel)
        {
            level += 1;
            health.increaseHealth(50);
            toNextLevel = 10 * level;
        }
    }

    public void updateText()
    {
        GameControl.control.experience = exp;
        GameControl.control.level = level;
        playerLevel.text = "Level: " + GameControl.control.level + "\nHealth: " + GameControl.control.health + "/" + GameControl.control.maxHealth +
            "\nExp: " + exp + "/" + toNextLevel;
    }


}
