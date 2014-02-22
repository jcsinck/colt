using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	public float speed;
	public int health;
	public GameObject enemyObject;

	private Animator anim;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1 * speed;
		anim = (Animator)this.GetComponent("Animator");
	}

	void Update() {
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
			health -= damage;

			rigidbody2D.velocity = Vector2.right * -1 * speed;

			if(health < 0)
			{
				anim.SetBool("destroyed", true);
				Destroy(enemyObject, .5f);
			}
		}
	}
}
