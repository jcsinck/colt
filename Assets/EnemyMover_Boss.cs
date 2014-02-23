using UnityEngine;
using System.Collections;

public class EnemyMover_Boss : MonoBehaviour {
	public int health;
	public GameObject enemyObject;
	public GameObject enemyBulletSpawner;
	public GameObject enemyBulletObject;
	public int speed;
	public bool isBoss;
	public float horizontalThreshold;

	private bool horizontalPositionReached;
	private float nextFireTime;
	GameObject boundaryBox;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1;
		boundaryBox = GameObject.Find("boundary_box");
		enemyBulletSpawner = GameObject.Find("bullet_spawner");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x <= horizontalThreshold
		   && !horizontalPositionReached)
		{
			horizontalPositionReached = true;
			rigidbody2D.velocity = Vector2.up * speed;
		}	

		BoxCollider2D boundaryBoxCollider = (BoxCollider2D) boundaryBox.GetComponent("BoxCollider2D");
		Vector2 boundaryBoxScale = boundaryBox.transform.lossyScale;

		BoxCollider2D boundaryCollider = (BoxCollider2D) boundaryBox.collider2D;
		float upperBound = boundaryBox.transform.position.y + boundaryCollider.size.y * boundaryBox.transform.lossyScale.y / 2.0f; //boundaryBox.transform.position.y + boundaryBox.transform.lossyScale.y;
		float lowerBound = boundaryBox.transform.position.y - boundaryCollider.size.y * boundaryBox.transform.lossyScale.y / 2.0f; //boundaryBox.transform.position.y - boundaryBox.transform.lossyScale.y;
		Mesh mesh = ((MeshFilter)boundaryBox.GetComponent(typeof(MeshFilter))).mesh;

		if(horizontalPositionReached 
		   && this.transform.position.y > upperBound)//boundaryBox.transform.position.y + boundaryBoxCollider.size.y * boundaryBoxScale.y / 2)
		{
			rigidbody2D.velocity *= -1;
		}
		else if(horizontalPositionReached
		        && this.transform.position.y < lowerBound)//boundaryBox.transform.position.y - boundaryBoxCollider.size.y * boundaryBoxScale.y / 2)
		{
			rigidbody2D.velocity = Vector2.up * speed;
		}

		float currentTime = Time.time;
		if(horizontalPositionReached)
		{
			if(nextFireTime < currentTime)
			{
				nextFireTime = currentTime + 1.0f;
				FireBullet();
			}
		}
	}

	void FireBullet()
	{
		Instantiate(enemyBulletObject, enemyBulletSpawner.transform.position, Quaternion.identity);
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
			
			if(health < 0)
			{
				if(!isBoss)
				{
					Destroy(enemyObject);
				}
				else
				{
					GameObject obj = GameObject.Find("enemy_spawner");
					EnemySpawner es = (EnemySpawner) obj.GetComponent("EnemySpawner");
					es.bossDefeated(this);
				}
			}
		}
	}
}
