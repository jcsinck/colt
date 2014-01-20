using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	public float speed;
	public int health;
	public GameObject enemyObject;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1 * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "BULLET")
		{
			Destroy(other.gameObject);

			if(health > 0)
			{
				health--;
				return;
			}

			Destroy(enemyObject);
		}
	}
}
