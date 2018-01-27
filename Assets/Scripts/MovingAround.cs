using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour {

	Vector3 startPos;
	float startAngle;
	float theta;
	float xAmplitude, yAmplitude;

	void Start () {
		startPos = transform.position;
		startAngle = Random.Range (0.0f, 360.0f);
		theta = startAngle;
		xAmplitude = Random.Range (2.0f, 4.0f);
		yAmplitude = Random.Range (2.0f, 4.0f);
	}
	
	void Update () {
		transform.position = startPos + new Vector3 (xAmplitude * Mathf.Cos (theta * Mathf.Deg2Rad), 
												yAmplitude * Mathf.Sin (theta * Mathf.Deg2Rad * 1.5f), 0);
		theta += Time.deltaTime * 5;
	}
}
