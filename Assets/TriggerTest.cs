using UnityEngine;
using System.Collections;

public class TriggerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "BOUNDARY")
		{
			return;
		}

		print("hello");
	}
}
