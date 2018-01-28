using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	public GameObject speechBubble;
	public Speeches instructions;
	public Uncle boss;
	public TV tv;
	public SignalController sigCon;

	public GameObject pauseCanvas;
	public GameObject pauseObject;

	[Space][ShowOnly]
	public bool playingGame = false;

	void Start () {
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			pauseCanvas.SetActive (true);
			pauseObject.SetActive (true);
		}
		if (!playingGame && instructions.HasEnded ()) {
			SetSpeechBubbleDisplay (false);
			instructions.gameObject.SetActive (false);
			sigCon.DoNextStage ();
			playingGame = true;
		} else if (playingGame && boss.rage >= 100) {
			instructions.RestartSubtitle ();
			SetSpeechBubbleDisplay (true);
			tv.TurnOnTV (false);
			playingGame = false;
			boss.GetComponent<SpeechPrompts> ().SpeakWith (SpeechTone.GaveUp);
		}
	}

	void SetSpeechBubbleDisplay (bool enabled) {
		speechBubble.SetActive (enabled);
	}
}
