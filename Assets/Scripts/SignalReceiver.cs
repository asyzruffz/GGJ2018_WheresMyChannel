using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour {

	[ShowOnly]
	public float signalStrength;

	bool inRange = false;
	RadioSignal currentSignal;
	
	void Update () {
		if (inRange) {
			ReceiveSignal ();
		}
	}

	void ReceiveSignal () {
		signalStrength = Vector2.Distance (transform.position, currentSignal.transform.position);
		Debug.Log ("Receiving signal at " + signalStrength);
	}

	void OnTriggerEnter2D (Collider2D other) {
		currentSignal = other.GetComponent<RadioSignal> ();
		if (currentSignal) {
			inRange = true;
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		inRange = false;
	}
}
