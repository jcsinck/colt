using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;

	public Transform bulletSpawner;
	public GameObject bullet;

	void Update()
	{
		bool spaceTapped = Input.GetKeyDown(KeyCode.Space);
		if(spaceTapped)
		{
			Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody2D.velocity = movement * speed;
	}
}
