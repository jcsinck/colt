using UnityEngine;
using System.Collections;

public class BulletMover : Bullet {
	public float speed;
	public GameObject bulletObject;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * speed;
	}

	public override bool DestroyOnContact()
	{
		return true;
	}

	public override int BulletDamage()
	{
		return 1;
	}
}
