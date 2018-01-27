using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncle : MonoBehaviour {

	[Header("Channel")]
	public ChannelType preference;
	[Range (0, 1)]
	public float signalThreshold = 0.8f;

	[Header("Attitude")]
	[Range(0,100)]
	public float rage;
	[ShowOnly]
	public float patience;
	[Space]
	public float temper = 2;
	public float coolOffTime = 3;
	public float coolRegenRate = 2;
	public float initialCoolBonus = 5;
	public float satisfiedDuration = 4;

	[Header("TV")]
	public SignalReceiver antenna;
	public SignalController channelChanger;
	
	float angerRate = 0;
	float satisfaction;

	void Start () {
		patience = initialCoolBonus + coolOffTime;
	}
	
	void Update () {
		bool inGame = GameController.Instance != null ? GameController.Instance.playingGame : true;

		if (inGame) {
			float signalStrength = 1 - antenna.DisturbanceNormalized ();

			if (signalStrength <= signalThreshold) {
				BecomingAngry ();
			} else {
				RegainCalmness ();
				WatchTV ();
			}
		}
		
		rage += angerRate * Time.deltaTime;
		rage = Mathf.Clamp (rage, 0.0f, 100.0f);
	}

	void BecomingAngry () {
		if (patience > 0) {
			patience -= Time.deltaTime;
			angerRate = 0;
		} else {
			angerRate = antenna.DisturbanceNormalized () * temper;
		}
	}

	void RegainCalmness () {
		patience = Mathf.Min (patience + coolRegenRate * Time.deltaTime, coolOffTime);
		angerRate = (patience >= coolOffTime) ? temper * -0.5f : 0;
	}

	void WatchTV () {
		satisfaction += Time.deltaTime;
		if (satisfaction >= satisfiedDuration) {
			satisfaction = 0;
			antenna.inRange = false;
			channelChanger.DoNextStage ();
		}
	}
}
