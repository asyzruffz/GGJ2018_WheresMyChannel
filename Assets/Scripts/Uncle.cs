using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncle : MonoBehaviour {

	public ChannelType unclePreference;
	[Range (0, 1)]
	public float signalThreshold = 0.8f;
	[Range(0,100)]
	public float rage;
	public float temper = 1;
	public float waitTime = 3;

	[Header("TV")]
	public SignalReceiver antenna;

	[Space]
	[SerializeField]
	float angerRate = 0;
	[SerializeField]
	float patience;

	void Start () {
		patience = waitTime;
	}
	
	void Update () {
		float signalStrength = 1 - antenna.DisturbanceNormalized ();

		if (signalStrength <= signalThreshold) {
			if (patience > 0) {
				patience -= Time.deltaTime;
			} else {
				BecomingAngry ();
			}
		} else {
			RegainCalmness ();
		}
	}

	void BecomingAngry () {
		angerRate = antenna.DisturbanceNormalized () * temper;
		rage += angerRate * Time.deltaTime;
		rage = Mathf.Clamp (rage, 0.0f, 100.0f);
	}

	void RegainCalmness () {
		angerRate = 0;
		patience = waitTime;
	}
}
