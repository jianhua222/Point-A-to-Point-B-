using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int health;
    public int experience;
    public int level;
    public int maxHealth;
    public int score;


	// Use this for initialization
	void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        Load();
	}
	
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        data.health = health;
        data.level = level;
        data.experience = experience;
        data.maxHealth = maxHealth;
        data.score = score;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            //Debug.Log("Load");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
            level = data.level;
            maxHealth = data.maxHealth;
            score = data.score;
        }
    }

    public void reset()
    {
        //Debug.Log("Reset");
        health = 100;
        experience = 0;
        level = 1;
        maxHealth = 100;
        score = 0;
        Save();
    }
}

[Serializable]
class PlayerData
{
    public int health;
    public int experience;
    public int level;
    public int maxHealth;
    public int score;
}
