using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public bool gameOver;
	public float scoreNumber;
	public int finalScore;
	public Text scoreCanvas;
	public Uncle uncle;
	public GameController gameController;

	// Use this for initialization
	void Start () 
	{
		scoreNumber = 0;
		finalScore = 0;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameController.playingGame) {
			if (uncle.rage >= 100) {
				gameOver = true;
			}
			finalScore = Mathf.FloorToInt (scoreNumber);
			scoreCanvas.text = finalScore.ToString ();
		}
	}

	void FixedUpdate()
	{
		if(gameController.playingGame)
		{
			if (!gameOver) 
			{
				scoreNumber += Time.deltaTime * 2;
			}
		}
	}
}
