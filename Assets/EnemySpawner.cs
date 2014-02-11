using UnityEngine;
using System.Collections;

public class EnemySpawnData {
	private int location;
	private int enemyType;
	private double ySpawnPercentage;
	private bool isBoss;
	
	public EnemySpawnData() {
		location = 10;
		enemyType = 1;
		ySpawnPercentage = -1;
		isBoss = false;
	}
	
	public EnemySpawnData(int loc, int eType)
	{
		location = loc;
		enemyType = eType;
		ySpawnPercentage = -1;
		isBoss = false;
	}
	
	public EnemySpawnData(int loc, int eType, double perc)
	{
		location = loc;
		enemyType = eType;
		ySpawnPercentage = perc;
		isBoss = false;
	}

	public EnemySpawnData(int loc, int eType, double perc, bool isBos)
	{
		location = loc;
		enemyType = eType;
		ySpawnPercentage = perc;
		isBoss = isBos;
	}
	
	public int getLocation()
	{
		return location;
	}
	
	public int getEnemyType()
	{
		return enemyType;
	}
	
	public double getYSpawnPercentage()
	{
		return ySpawnPercentage;
	}
}

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyObject;
	public GameObject enemyObjectTwo;
	public GameObject enemyObjectThree;
	public GameObject enemyObjectFour;

	public GameObject playerObjectOne;
	public GameObject playerObjectTwo;

	public Transform enemySpawnerObject;
	public float fireRate;
	public float border;
	public float topLimit;

	private float nextFireTime;
	private float sceneLoadTime;
	private ArrayList enemySpawnSequence;
	private ArrayList enemyTypeList;
	private GameData gameData;

	void Start () {
		enemySpawnSequence = new ArrayList();
		enemySpawnSequence.Add(new EnemySpawnData(5, 1, 1));
		enemySpawnSequence.Add(new EnemySpawnData(6, 1, 1));
		enemySpawnSequence.Add(new EnemySpawnData(7, 1, 1));
		enemySpawnSequence.Add(new EnemySpawnData(8, 1, 1));
		enemySpawnSequence.Add(new EnemySpawnData(9, 2, 0));
		enemySpawnSequence.Add(new EnemySpawnData(10, 2, 0));
		enemySpawnSequence.Add(new EnemySpawnData(11, 2, 0));
		enemySpawnSequence.Add(new EnemySpawnData(12, 2, 0));
		enemySpawnSequence.Add(new EnemySpawnData(16, 0, .1));
		enemySpawnSequence.Add(new EnemySpawnData(16, 0, .3));
		enemySpawnSequence.Add(new EnemySpawnData(16, 0, .5));
		enemySpawnSequence.Add(new EnemySpawnData(16, 0, .7));
		enemySpawnSequence.Add(new EnemySpawnData(20, 0, .18));
		enemySpawnSequence.Add(new EnemySpawnData(20, 0, .36));
		enemySpawnSequence.Add(new EnemySpawnData(20, 0, .54));
		enemySpawnSequence.Add(new EnemySpawnData(20, 0, .72));
		enemySpawnSequence.Add(new EnemySpawnData(20, 0, .90));
		enemySpawnSequence.Add(new EnemySpawnData(23, 0, .2));
		enemySpawnSequence.Add(new EnemySpawnData(23, 0, .3));
		enemySpawnSequence.Add(new EnemySpawnData(23, 0, .7));
		enemySpawnSequence.Add(new EnemySpawnData(23, 0, .8));
		enemySpawnSequence.Add(new EnemySpawnData(26, 0, .4));
		enemySpawnSequence.Add(new EnemySpawnData(26, 0, .6));
		enemySpawnSequence.Add(new EnemySpawnData(28, 0, .5));
		enemySpawnSequence.Add(new EnemySpawnData(30, 3, .5));
		
		enemyTypeList = new ArrayList();
		enemyTypeList.Add(enemyObject);
		enemyTypeList.Add(enemyObjectTwo);
		enemyTypeList.Add(enemyObjectThree);
		enemyTypeList.Add(enemyObjectFour);

		sceneLoadTime = Time.time;

		GetGlobalGameData();
	}

	// Update is called once per frame
	void Update () {
		if(enemySpawnSequence.Count <= 0)
			return;

		float currentTime = Time.time - sceneLoadTime;
		EnemySpawnData data = (EnemySpawnData) enemySpawnSequence[0];
		float yCoordinate = determineBulletLocationWithPercentage(data.getYSpawnPercentage());

		UnityEngine.Object enemyToSpawn = (UnityEngine.Object) enemyTypeList[data.getEnemyType()];
		if(currentTime >= data.getLocation())
		{
			Instantiate(enemyToSpawn, 
			            new Vector3(enemySpawnerObject.position.x, yCoordinate, enemySpawnerObject.position.z), 
			            enemySpawnerObject.rotation);
			enemySpawnSequence.RemoveAt(0);
		}
	}

	float determineBulletLocationWithPercentage(double percentage)
	{
		float distanceFromBottom = topLimit * (float) percentage;
		return enemySpawnerObject.position.y + distanceFromBottom;
	}

	public void bossDefeated(MonoBehaviour bossObject)
	{
		Destroy(bossObject.GetComponent("EnemyMover_Boss"));
		Application.LoadLevel(0);
	}

	private void GetGlobalGameData()
	{
		GameObject gameDataObject = GameObject.FindGameObjectWithTag("GAME_DATA");
		if(gameDataObject == null)
		{
			Application.LoadLevel(0);
		}
		else
		{
			gameData = (GameData) gameDataObject.GetComponent("GameData");
			InstantiatePlayerShip();
		}
	}

	private void InstantiatePlayerShip()
	{
		GameObject targetGameObject = null;
		Quaternion rotation = Quaternion.identity;
		if(gameData.selectedShipType == 0)
		{
			targetGameObject = playerObjectOne;
			rotation = Quaternion.Euler(0, 0, 270.0f);
		}
		else if(gameData.selectedShipType == 1)
		{
			targetGameObject = playerObjectTwo;
		}
		else
		{
			targetGameObject = playerObjectTwo;
		}

		Instantiate(targetGameObject, new Vector3(1.41f, 0.074f), rotation);
	}
}
