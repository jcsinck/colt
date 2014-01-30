using UnityEngine;
using System.Collections;

public class ShipSelectGui : MonoBehaviour {
	public const int BUTTON_WIDTH = 100;
	public const int BUTTON_HEIGHT = 100;
	public const int BUTTON_SPACING = 15;

	private float screenWidth;
	private float screenHeight;

	private GameData gameData;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		print(Screen.width);
		print(Screen.height);

		gameData = (GameData) GameObject.FindGameObjectWithTag("GAME_DATA").GetComponent("GameData");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width, Screen.height), "Select your ship");

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2 - BUTTON_WIDTH - BUTTON_SPACING, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SHIP ONE")) {
			gameData.selectedShipType = 0;
			Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SHIP TWO")) {
			gameData.selectedShipType = 1;
			Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(screenWidth / 2 - BUTTON_WIDTH / 2 + BUTTON_WIDTH + BUTTON_SPACING, 
		                       screenHeight / 2 - BUTTON_HEIGHT / 2, 
		                       BUTTON_WIDTH, 
		                       BUTTON_HEIGHT), 
		              "SHIP THREE")) {
			gameData.selectedShipType = 2;
			Application.LoadLevel(2);
		}
	}
}
