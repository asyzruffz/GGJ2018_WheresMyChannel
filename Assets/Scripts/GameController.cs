using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	public GameObject speechBubble;
	public Speeches instructions;
	public Uncle boss;

	[Space][ShowOnly]
	public bool playingGame = false;

	void Start () {
		
	}
	
	void Update () {
		if (!playingGame && instructions.HasEnded ()) {
			SetSpeechBubbleDisplay (false);
			playingGame = true;
		} else if (playingGame && boss.rage >= 100) {
			instructions.RestartSubtitle ();
			playingGame = false;
		}
	}

	void SetSpeechBubbleDisplay (bool enabled) {
		speechBubble.SetActive (enabled);
	}
}
