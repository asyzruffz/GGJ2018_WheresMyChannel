﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Speeches : MonoBehaviour {

	public float timePerPage = 1;
	public KeyCode skipKey = KeyCode.Space;
	public bool startOnAwake = true;
	[TextArea]
	public string[] subtitleText;
	[Header("Sound")]
	public AudioClip textSound;
	[Header ("Misc")]
	public TV tv;

	private Text displayText;
	private AudioSource audioSource;
	private float timer = 0;
	private int currentPage = 0;
	private bool textStart = true;
	private bool textEnd = false;

	void Start() {
		displayText = GetComponent<Text> ();
		audioSource = GetComponent<AudioSource> ();
		textStart = startOnAwake;
	}

	void Update () {
		if (textEnd || !textStart) {
			if (!startOnAwake && (Input.GetKeyDown (skipKey) || Input.GetMouseButtonDown (0)) 
				&& !GameController.Instance.pauseGame) {
				textStart = true;
				tv.TurnOnTV (true);
			}
			return;
		}

		// Set the text to be displayed
		if (subtitleText.Length > 0) {
			displayText.text = subtitleText[currentPage];
		}

		if ((timer >= timePerPage || Input.GetKeyDown (skipKey) || Input.GetMouseButtonDown (0)) && !GameController.Instance.pauseGame) {
			GoToNextPage ();
		}

		timer += Time.deltaTime;
	}

	public void RestartSubtitle() {
		currentPage = 0;
		timer = 0;
		textStart = startOnAwake;
		textEnd = false;
	}

	public bool HasEnded() {
		return textEnd;
	}

	// Return false if at the last page
	void GoToNextPage () {
		timer = 0;
		currentPage++;

		if (currentPage >= subtitleText.Length) {
			SetSubtitleToEnd ();
		} else {
			if (textSound) {
				audioSource.PlayOneShot (textSound);
			}
		}
	}

	void SetSubtitleToEnd () {
		displayText.text = "";
		textEnd = true;
	}
}
