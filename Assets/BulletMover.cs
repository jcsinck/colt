using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {
	public float speed;
	public GameObject bulletObject;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * speed;
	}
}
