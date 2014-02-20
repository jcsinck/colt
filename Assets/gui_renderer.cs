using UnityEngine;
using System.Collections;

public class gui_renderer : MonoBehaviour {

	void OnGUI() {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		float weapTextHeight = screenHeight * .02f; //4% of total screen height
		float weapImageHeight = screenHeight * .07f;
		float scoreTextHeight = screenHeight * .08f;

		GUIStyle centerStyle = new GUIStyle(GUI.skin.label);
		centerStyle.alignment = TextAnchor.MiddleCenter;
		GUIStyle rightStyle = new GUIStyle(GUI.skin.label);
		rightStyle.alignment = TextAnchor.MiddleRight;
		rightStyle.fontSize = 20;

		GUI.Label(new Rect(105, 5, 50, weapTextHeight), "MAIN", centerStyle);
		GUI.Label(new Rect(225, 5, 50, weapTextHeight), "SUB", centerStyle);

		Texture2D weaponTexture = Resources.Load<Texture2D>("bullet_bill");
		GUI.DrawTexture(new Rect(105, 5 + weapTextHeight, 50, weapImageHeight), weaponTexture, ScaleMode.ScaleToFit, true, 1.0f);

		Texture2D subWeaponTexture = Resources.Load<Texture2D>("thunderbolt");
		GUI.DrawTexture(new Rect(225, 5 + weapTextHeight, 50, weapImageHeight), subWeaponTexture, ScaleMode.ScaleToFit, true, 1.0f);

		Texture2D meterTexture = Resources.Load<Texture2D>("meter");
		GUI.DrawTexture(new Rect(400, 5, 600, scoreTextHeight), meterTexture, ScaleMode.StretchToFill, true, 1.0f);

		GUI.Label(new Rect(screenWidth - 450, 5, 280, scoreTextHeight), "Score: 314159265351337", rightStyle);
	}
}
