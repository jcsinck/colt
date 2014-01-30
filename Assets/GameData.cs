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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getMainWeaponStageWithType(int type)
	{
		return mainWeaponStages[type];
	}

	public void powerupAcquiredWithType(int type)
	{
		mainWeaponStages[type]++;
	}
}
