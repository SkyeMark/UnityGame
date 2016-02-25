using UnityEngine;
using System.Collections;

// Use PlayerPrefs.() to save all values
// PlayerPrefs.SetInt("StringNameOfValue", IntegerValue);
// PlayerPrefs.SetString("StringNameOfValue", "StringToSave");
// PlayerPrefs.Save();  This saves all player pref values.
public class CheckPoint1 : MonoBehaviour {
	public bool Checkpoint1Activated = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnCheckpointActivate1(){ // Save the position values of Checkpoint1
		PlayerPrefs.SetFloat ("PlayerProgressX", 284f); // X value for position
		PlayerPrefs.SetFloat ("PlayerProgressY", 1.98f); // Y value for position
		PlayerPrefs.SetInt("SceneToLoad", 1); // The scene to load 
		// Found in: File > BuildSettings > IntegerValue Corresponding to scene
		PlayerPrefs.Save(); // Save the values
		Checkpoint1Activated = true; // This will stop the checkpoint from reactivating over and over

	}

}