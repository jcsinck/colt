using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {
	public float speed;
	public GameObject bulletObject;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "ENEMY")
		{
			Destroy(other.gameObject);
			Destroy(bulletObject);
		}
	}
//	void OnCollisionEnter2D(Collision2D col)
//	{
//		if(col.gameObject.tag == "ENEMY")
//		{
//			Destroy(col.gameObject);
//			Destroy(this);
//		}
//	}
}
