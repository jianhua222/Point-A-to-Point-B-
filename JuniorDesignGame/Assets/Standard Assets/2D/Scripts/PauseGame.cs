using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    //public Transform player;
    public Transform controllerSetting;
    



	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Exit()
    {
        GameControl.control.Save();
        SceneManager.LoadScene("Scene1");
    }

    public void ViewContolScheme()
    {
        if (controllerSetting.gameObject.activeInHierarchy == false) {
            controllerSetting.gameObject.SetActive(true);
        } else {
            controllerSetting.gameObject.SetActive(false);
        }
        
        
    }
}

