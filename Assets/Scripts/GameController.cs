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
	[ShowOnly]
	public bool pauseGame = false;

	void Start () {
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			pauseCanvas.SetActive (true);
			pauseObject.SetActive (true);
			SetPaused (true);
		}
		if (!playingGame && instructions.HasEnded ()) {
			SetSpeechBubbleDisplay (false);
			instructions.gameObject.SetActive (false);
			sigCon.DoNextStage ();
			Cursor.visible = false;
			playingGame = true;
		} else if (playingGame && boss.rage >= 100) {
			instructions.RestartSubtitle ();
			SetSpeechBubbleDisplay (true);
			tv.TurnOnTV (false);
			playingGame = false;
			Cursor.visible = true;
			boss.GetComponent<SpeechPrompts> ().SpeakWith (SpeechTone.GaveUp);
		}
	}

	void SetSpeechBubbleDisplay (bool enabled) {
		speechBubble.SetActive (enabled);
	}

	public void SetPaused (bool enabled) {
		pauseGame = enabled;
		tv.PauseTV (enabled);
		Time.timeScale = enabled ? 0 : 1;
		Cursor.visible = enabled ? true : (playingGame ? false : true);
	}
}
