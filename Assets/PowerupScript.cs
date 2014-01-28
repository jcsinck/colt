using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1;
	}
}
