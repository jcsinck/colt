using UnityEngine;
using System.Collections;

public class EnemyScript_Bezier : MonoBehaviour {
	float StartPointX = 0;
	float StartPointY = 0;
	public float ControlPointX = 4;
	public float ControlPointY = 10;
	public float EndPointX  = 10;
	public float EndPointY  = 0;
	float CurveX;
	float CurveY;
	float BezierTime = 0;
	public float speedReductionFactor = 1;

	public float controlPointXIncrement;
	public float controlPointYIncrement;
	public float endPointXIncrement;
	public float endPointYIncrement;

	public int health;
	public GameObject enemyObject;

	void Start()
	{
		StartPointX = this.transform.position.x;
		StartPointY = this.transform.position.y;
		ControlPointX = StartPointX + controlPointXIncrement;
		ControlPointY = StartPointY + controlPointYIncrement;
		EndPointX = StartPointX + endPointXIncrement;
		EndPointY = StartPointY + endPointYIncrement;
	}

	// Update is called once per frame
	void Update () {
		BezierTime = BezierTime + Time.deltaTime/speedReductionFactor;
		
//		if (BezierTime >= 3)
//		{
//			BezierTime = 0;
//		}
		
		CurveX = (((1-BezierTime)*(1-BezierTime)) * StartPointX) + (2 * BezierTime * (1 - BezierTime) * ControlPointX) + ((BezierTime * BezierTime) * EndPointX);
		CurveY = (((1-BezierTime)*(1-BezierTime)) * StartPointY) + (2 * BezierTime * (1 - BezierTime) * ControlPointY) + ((BezierTime * BezierTime) * EndPointY);
		transform.position = new Vector3(CurveX, CurveY, 0.0f);
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
