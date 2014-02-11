using UnityEngine;
using System.Collections;

public class MashLightning : Bullet {

	private float spawnTime;
	public GameObject bulletObject;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		if(currentTime > spawnTime + .05f)
		{
			Destroy(this);
			Destroy(bulletObject);
		}
	}

	public override bool DestroyOnContact()
	{
		return false;
	}

	public override int BulletDamage()
	{
		return 10;
	}
}
