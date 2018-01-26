using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVScreen : MonoBehaviour {

	public Image channelView;
	public Image staticView;
	[Space]
	public SignalReceiver antenna;

	void Start () {
		
	}
	
	void Update () {
		if (antenna.inRange) {
			staticView.color = new Color (staticView.color.r, staticView.color.g, staticView.color.b, antenna.DisturbanceNormalized ());
		}
	}
}
