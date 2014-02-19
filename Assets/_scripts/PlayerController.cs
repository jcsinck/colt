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
	public float fireRate;
	public float subFireRate;

	public Transform bulletSpawner;
	public GameObject bullet;
	public GameObject subWeaponBullet;
	public GameObject subWeaponBulletTwo;
	public GameObject shipObject;

	private float nextMainWeaponFireTime;
	private float nextSubWeaponFireTime;
	private GameData gameData;
	private bool subWeaponRapidFire;
	private bool pauseGame;

	void Start()
	{
		GameObject gameDataObject = GameObject.FindGameObjectWithTag("GAME_DATA");
		if(gameDataObject == null)
		{
			Application.LoadLevel(0);
		}
		else
		{
			gameData = (GameData) gameDataObject.GetComponent("GameData");
			SetWeaponFireRates();
			pauseGame = false;
		}
	}

	void Update()
	{
		float currentTime = Time.time;
		bool spaceTapped = Input.GetKey(KeyCode.Space) && !pauseGame;
		if(spaceTapped && currentTime > nextMainWeaponFireTime)
		{
			FireMainWeapon();
			nextMainWeaponFireTime = currentTime + fireRate;
		}

		bool nTapped = false;
		if(subWeaponRapidFire)
			nTapped = Input.GetKey(KeyCode.N);
		else
			nTapped = Input.GetKeyDown(KeyCode.N);

		nTapped = nTapped && !pauseGame;
		if(nTapped && currentTime > nextSubWeaponFireTime)
		{
			FireSubWeapon();
			nextSubWeaponFireTime = currentTime + subFireRate;
		}

		bool pausePressed = Input.GetKeyDown(KeyCode.Return);
		if(pausePressed)
			flipPauseState();
	}

	void FixedUpdate()
	{
		float moveHorizontal = 0f;
		float moveVertical = 0f;

		bool upHeld = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
		if(upHeld)
			moveVertical = 1.0f;
		
		bool downHeld = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
		if(downHeld)
			moveVertical = -1.0f;
		
		bool leftHeld = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
		if(leftHeld)
			moveHorizontal = -1.0f;
		
		bool rightHeld = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
		if(rightHeld)
			moveHorizontal = 1.0f;

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rigidbody2D.velocity = movement * speed;

		this.transform.position = new Vector3(
			Mathf.Clamp(this.transform.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(this.transform.position.y, boundary.zMin, boundary.zMax));
	}

	void FireMainWeapon()
	{
		int mainWeaponStage = gameData.getMainWeaponStageWithType(gameData.currentMainWeaponType);
		if(mainWeaponStage > 0)
		{
			Instantiate(bullet, 
			            new Vector3(bulletSpawner.position.x, bulletSpawner.position.y + .2f), 
			            bulletSpawner.rotation);
			Instantiate(bullet, 
			            new Vector3(bulletSpawner.position.x, bulletSpawner.position.y - .2f), 
			            bulletSpawner.rotation);
		}
		else
		{
			Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
		}
	}

	void FireSubWeapon()
	{
		if(gameData.subWeaponType == 0)
			Instantiate(subWeaponBullet, bulletSpawner.position, bulletSpawner.rotation);
		else if(gameData.subWeaponType == 1)
			Instantiate(subWeaponBulletTwo, bulletSpawner.position, Quaternion.Euler(0f, 0f, 90.0f));
		else
			Instantiate(subWeaponBulletTwo, bulletSpawner.position, Quaternion.Euler(0f, 0f, 90.0f));
	}

	void SetWeaponFireRates()
	{
		fireRate = gameData.getPrimaryWeaponFireRateForWeaponType(gameData.selectedShipType);
		subFireRate = gameData.getSubWeaponFireRateForWeaponType(gameData.subWeaponType);
		subWeaponRapidFire = gameData.isSubWeaponRapidFireWithWeapon(gameData.subWeaponType);
	}

	void flipPauseState()
	{
		pauseGame = !pauseGame;
		if(pauseGame)
			Time.timeScale = 0.0f;
		else
			Time.timeScale = 1.0f;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "ENEMY"
		   || other.gameObject.tag == "ENEMY_BULLET")
		{
			Destroy(other.gameObject);
			Destroy(shipObject);
			Application.LoadLevel(0);
		}
		if(other.gameObject.tag == "POWERUP")
		{
			gameData.powerupAcquiredWithType(gameData.currentMainWeaponType);
			Destroy(other.gameObject);
		}
	}
}
