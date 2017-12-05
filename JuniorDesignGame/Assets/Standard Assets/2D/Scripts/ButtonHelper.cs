using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(GameControl.control.reset);
	}
	

}
