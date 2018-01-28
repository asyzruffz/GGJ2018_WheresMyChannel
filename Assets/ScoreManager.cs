using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public bool gameOver;
	public float scoreNumber;
	public int finalScore;
	public Text scoreCanvas;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		finalScore = Mathf.FloorToInt (scoreNumber);
		scoreCanvas.text = finalScore.ToString ();
	}

	void FixedUpdate()
	{
		if (!gameOver) 
		{
			scoreNumber += Time.deltaTime * 2;
		}
	}
}
