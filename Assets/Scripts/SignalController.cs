using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SignalController : MonoBehaviour {

	public GameObject signalPrefab;
	public Transform[] spawnPoints;
	[Space]
	public SpeechPrompts prompt;

	RandomSample sample;
	List<GameObject> signalList = new List<GameObject> ();
	bool changeLvl;
	int currLvl, currTrial;
	ChannelType trueChannel;

	void Start () {
		sample = new RandomSample (spawnPoints.Length);
		currLvl = 1;
		currTrial = 0;
	}
	
	void Update () {
		if (changeLvl/* || Input.GetMouseButtonDown (1)*/) {
			changeLvl = false;
			SetStage (currLvl, currTrial);
			currTrial++;
			
			if (currTrial >= 3) {
				currLvl++;
				currTrial = 0;
			}
		}
	}

	void SetStage (int level, int trial) {
		ResetStage ();
		trial = trial % (Enum.GetNames (typeof (ChannelType)).Length);
		trueChannel = (ChannelType)trial;

		GameObject tempSignal;
		switch (level) {
			case 1:
				for (int i = 0; i < 2; i++) {
					tempSignal = Instantiate (signalPrefab, spawnPoints[sample.Next()].position + GenerateOffset (), Quaternion.identity, transform);
					tempSignal.GetComponent<TVSignal> ().channelType = (ChannelType)trial;
					tempSignal.name = ((ChannelType)trial).ToString () + "TVSignal";
					signalList.Add (tempSignal);
				}
				break;
			case 2:
				for (int i = 0; i < 3; i++) {
					tempSignal = Instantiate (signalPrefab, spawnPoints[sample.Next ()].position + GenerateOffset (), Quaternion.identity, transform);
					tempSignal.GetComponent<TVSignal> ().channelType = (ChannelType)i;
					tempSignal.name = ((ChannelType)i).ToString () + "TVSignal";
					signalList.Add (tempSignal);
				}
				break;
			default:
			case 3:
				for (int i = 0; i < 2; i++) {
					tempSignal = Instantiate (signalPrefab, spawnPoints[sample.Next ()].position + GenerateOffset (), Quaternion.identity, transform);
					tempSignal.GetComponent<TVSignal> ().channelType = (ChannelType)trial;
					tempSignal.AddComponent<MovingAround>();
					tempSignal.name = ((ChannelType)trial).ToString () + "TVSignal";
					signalList.Add (tempSignal);
				}
				trial = (trial + 1) % (Enum.GetNames (typeof (ChannelType)).Length);
				tempSignal = Instantiate (signalPrefab, spawnPoints[sample.Next ()].position + GenerateOffset (), Quaternion.identity, transform);
				tempSignal.GetComponent<TVSignal> ().channelType = (ChannelType)trial;
				tempSignal.AddComponent<MovingAround> ();
				tempSignal.name = ((ChannelType)trial).ToString () + "TVSignal";
				signalList.Add (tempSignal);
				break;
		}

		prompt.SpeakWith (SpeechTone.Bored);
	}

	void ResetStage () {
		sample.Reset ();
		foreach (GameObject sig in signalList) {
			Destroy (sig);
		}
		signalList.Clear ();
	}

	Vector3 GenerateOffset () {
		Vector3 offset = Random.insideUnitCircle;
		return offset;
	}
	
	public void DoNextStage () {
		changeLvl = true;
	}

	public ChannelType CorrectChannelSignal () {
		return trueChannel;
	}
}
