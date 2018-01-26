using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour {

	[ShowOnly]
	public bool inRange = false;
	[ShowOnly]
	public float signalDisturbance;
	public TVSignal currentSignal;
	
	void Update () {
		if (inRange) {
			ReceiveSignal ();
		}
	}

	void ReceiveSignal () {
		signalDisturbance = Vector2.Distance (transform.position, currentSignal.transform.position);
		//Debug.Log ("Receiving signal at " + signalDisturbance);
	}

	public float DisturbanceNormalized () {
		if (inRange) {
			float disturbanceNormalized = Mathf.InverseLerp (0, currentSignal.SignalRadius (), signalDisturbance);
			disturbanceNormalized = Mathf.Clamp01 (disturbanceNormalized);
			return disturbanceNormalized;
		} else {
			return 1;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		currentSignal = other.GetComponent<TVSignal> ();
		if (currentSignal) {
			inRange = true;
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		inRange = false;
	}
}
