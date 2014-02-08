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
			Bullet bullet = (Bullet) other.gameObject.GetComponent(typeof(Bullet));
			if(bullet.DestroyOnContact())
			{
				Destroy(other.gameObject);
			}

			int damage = bullet.BulletDamage();
			if(health > 0)
			{
				health -= damage;
				return;
			}

			Destroy(enemyObject);
		}
	}
}
