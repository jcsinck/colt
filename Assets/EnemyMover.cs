using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1 * speed;
	}
}
