using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    Experience exp;
    GameObject player;
    void start()
    {
        GameControl.control.Load();
    }
	public void ChangeToScene (string sceneToChangeTo)
    {
        Time.timeScale = 1;
        GameControl.control.health = GameControl.control.maxHealth;
        GameControl.control.Save();
        SceneManager.LoadScene(sceneToChangeTo);
	}

    public void exitGame()
    {
        GameControl.control.health = GameControl.control.maxHealth;
        GameControl.control.Save();
        Application.Quit();
    }

}
