using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {

	void Start () {
		rigidbody2D.velocity = Vector2.right * -1;
	}
}
