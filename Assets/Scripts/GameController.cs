using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	public GameObject speechBubble;
	public Subtitles instructions;

	public bool playingGame = false;

	void Start () {
		
	}
	
	void Update () {
		if (!playingGame && instructions.HasEnded ()) {
			SetSpeechBubbleDisplay (false);
			playingGame = true;
		}
	}

	void SetSpeechBubbleDisplay (bool enabled) {
		speechBubble.SetActive (enabled);
	}
}
