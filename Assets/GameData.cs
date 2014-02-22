using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
	//ship data
	public int selectedShipType;

	//main weapon data
	public int totalWeaponTypes;
	public int currentMainWeaponType;
	public int[] mainWeaponStages;

	//sub weapon data
	public int subWeaponType;
	public int subWeaponStage;

	//progression data
	public int lastCheckpointReached;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);

		totalWeaponTypes = 8;
		currentMainWeaponType = 0;
		mainWeaponStages = new int[totalWeaponTypes];

		for(int i = 0; i < totalWeaponTypes; i++)
		{
			mainWeaponStages[i] = 0;
		}

		subWeaponType = 0;
		subWeaponStage = 0;

		lastCheckpointReached = 0;
	}

	public int getMainWeaponStageWithType(int type)
	{
		return mainWeaponStages[type];
	}

	public void powerupAcquiredWithType(int type)
	{
		mainWeaponStages[type]++;
	}

	public float getPrimaryWeaponFireRateForWeaponType(int weapType)
	{
		if(weapType == 0)
			return 0.1f;
		else if(weapType == 1)
			return 0.45f;

		return 0.1f;
	}

	public float getSubWeaponFireRateForWeaponType(int weapType)
	{
		if(weapType == 0)
			return 0.3f;
		else if(weapType == 1)
			return 0.01f;

		return 0.1f;
	}

	public bool isSubWeaponRapidFireWithWeapon(int weapType)
	{
		if(subWeaponType == 1)
			return false;

		return true;
	}

	public int getLastCheckpointReached()
	{
		return lastCheckpointReached;
	}

	public void checkpointReached()
	{
		lastCheckpointReached++;
	}
}
