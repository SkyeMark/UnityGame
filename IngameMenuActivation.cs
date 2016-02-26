using UnityEngine;
using System.Collections;

public class IngameMenuActivation : MonoBehaviour {
	public Transform LoadMainMenu, Quit, MusicSlider, MusicMute; // Elements to move in or out of GUI
	public Vector2[] GuiPositions;
	public bool EscapePressed;
	public bool Toggle;
	// Use this for initialization
	void Start () {
		GuiPositions = new Vector2[6]; // Hold two positions: show and hide

		GuiPositions[0] = new Vector2(17.8f, 666f); // Hide all elements here index 0

		GuiPositions[1] = new Vector2(4.275f, 194.3f); // Show element 1: Load main menu button
		GuiPositions[2] = new Vector2(4.275f, 149.2f); // Show element 2: Quit game button
		GuiPositions[3] = new Vector2(-222f, 236f); // Show element 3: Music slider
		GuiPositions[4] = new Vector2(-349f, 236f); // Show element 4: Music mute button	
	}

	// Update is called once per frame
	void Update () {
		EscapePressed = Input.GetKeyDown (KeyCode.Escape);
		if (EscapePressed) { // This works like a toggle switch; pressing escape will display or hide ingame menu elements
			Toggle = !Toggle;
			if (Toggle == true) {
				LoadMainMenu.GetComponent<RectTransform> ().localPosition = GuiPositions [1]; // Move main menu button into view
				Quit.GetComponent<RectTransform> ().localPosition = GuiPositions [2]; // Move quit into view
				MusicSlider.GetComponent<RectTransform> ().localPosition = GuiPositions [3]; // Music slider for volume
				MusicMute.GetComponent<RectTransform> ().localPosition = GuiPositions [4]; // Move mute into view
			} else if (Toggle == false) {
				LoadMainMenu.GetComponent<RectTransform> ().localPosition = GuiPositions [0]; // Move everything back out of view
				Quit.GetComponent<RectTransform> ().localPosition = GuiPositions [0]; 
				MusicSlider.GetComponent<RectTransform> ().localPosition = GuiPositions [0];
				MusicMute.GetComponent<RectTransform> ().localPosition = GuiPositions [0];

			}
				
		}
	}


}
