using UnityEngine;
using System.Collections;

public class guiScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,150,200), "-*_<COAL TRAIN>_*-");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,130,70), "PLAY GAME")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,120,130,70), "STFU")) {
			Application.Quit();
		}
	}
}
