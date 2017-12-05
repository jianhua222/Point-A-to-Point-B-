using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {
	
	// Update is called once per frame
	public void ChangeVolume (float newVolume) {
        AudioListener.volume = newVolume;
	}
}
