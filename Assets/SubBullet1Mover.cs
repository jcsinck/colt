using UnityEngine;
using System.Collections;

public class SubBullet1Mover : Bullet {
	public float speed;
	public float radius;

	private float spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
		rigidbody2D.velocity = new Vector2(speed, Mathf.Sin(Time.time - spawnTime));
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(speed, Mathf.Cos((Time.time - spawnTime) * 25) * radius);
	}
}
