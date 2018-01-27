﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TVScreen : MonoBehaviour {
	
	public SignalReceiver antenna;

	[Header ("Screen")]
	public Animator channelView;
	public Image staticView;

	[Header("Speaker")]
	public AudioMixer soundMixer;
	public AudioClip staticSound;
	public AudioClip[] channelList;

	AudioSource[] audioSources;
	int prevChannel = 0;

	void Start () {
		audioSources = GetComponents<AudioSource> ();

		// Assign the noise
		if (staticSound) {
			audioSources[0].clip = staticSound;
			audioSources[0].Play ();
		} else {
			Debug.Log ("No noise found!");
		}

		// Assign the channel sounds
		if (channelList.Length > 0) {
			audioSources[1].clip = channelList[0];
			audioSources[1].Play ();
		} else {
			Debug.Log ("No channel sound found!");
		}
	}
	
	void Update () {
		if (antenna.inRange) {
			int channelType = (int)antenna.currentSignal.channelType;
			channelView.SetInteger ("ChannelState", channelType);
			staticView.color = new Color (staticView.color.r, staticView.color.g, staticView.color.b, antenna.DisturbanceNormalized ());

			if (prevChannel != channelType) {
				audioSources[1].clip = channelList[channelType];
				audioSources[1].Play ();
				prevChannel = channelType;
			}

			InterpolateSound (1 - antenna.DisturbanceNormalized ());
		}
	}

	void InterpolateSound (float value) {
		soundMixer.SetFloat ("ChannelVolume", MapValueToVolume (value));
		soundMixer.SetFloat ("NoiseVolume", MapValueToVolume (1 - value));
	}

	// Helper function to map normalized value to volume amount
	float MapValueToVolume (float value) {
		if (value < 0.01f) {
			// Totally mute it below 0.01 threshold
			return -80;
		} else {
			return Mathf.Lerp (-20, 0, value);
		}
	}
}
