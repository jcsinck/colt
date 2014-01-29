using UnityEngine;
using System.Collections;

public class SubWeaponSelect : MonoBehaviour {
	public const int BUTTON_WIDTH = 500;
	public const int BUTTON_HEIGHT = 150;
	public const int BUTTON_SPACING = 15;
	
	private float screenWidth;
	private float screenHeight;

	private GUIStyle headerTextStyle;
	
	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		print(Screen.width);
		print(Screen.height);

		headerTextStyle = new GUIStyle();
		headerTextStyle.fontSize = 32;
		headerTextStyle.alignment = TextAnchor.UpperCenter;
		headerTextStyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width, Screen.height), "Select your ship", headerTextStyle);

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2 - BUTTON_HEIGHT - BUTTON_SPACING, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SUB WEAPON ONE")) {
			Application.LoadLevel(3);
		}

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SUB WEAPON TWO")) {
			Application.LoadLevel(3);
		}

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2 + BUTTON_HEIGHT + BUTTON_SPACING, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SUB WEAPON THREE")) {
			Application.LoadLevel(3);
		}
	}
}
