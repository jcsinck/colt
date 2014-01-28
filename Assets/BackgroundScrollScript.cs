using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x - 0.01f, this.transform.position.y, 1.0f);
	}
}
