using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public string scene;
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
