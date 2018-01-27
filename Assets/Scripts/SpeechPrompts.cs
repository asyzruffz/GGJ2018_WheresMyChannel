using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechPrompts : MonoBehaviour {

	[Header("References")]
	public GameObject speechBubble;
	public Text theText;
	public SignalController sigCon;
	[Space]
	public float speechDuration = 1.5f;

	[Header ("Sfx")]
	public AudioClip[] voices;

	[Header ("Monologues")]
	[TextArea]
	public string switchToSport;
	[TextArea]
	public string switchToNews;
	[TextArea]
	public string switchToConcert;
	[TextArea]
	public string wrongChannel;
	[TextArea]
	public string stopWatching;

	AudioSource mouth;

	void Start () {
		mouth = GetComponent<AudioSource> ();
	}
	
	public void SpeakWith (SpeechTone tone) {
		StopAllCoroutines ();

		string tempString;
		switch (tone) {
			case SpeechTone.Bored:
				switch (sigCon.CorrectChannelSignal ()) {
					case ChannelType.Sport:
						theText.text = switchToSport;
						break;
					case ChannelType.News:
						theText.text = switchToNews;
						break;
					case ChannelType.Concert:
						theText.text = switchToConcert;
						break;
					default:
						theText.text = "When will this commercial end?";
						break;
				}
				break;
			case SpeechTone.Annoyed:
				tempString = wrongChannel.Replace ("<channeltype>", sigCon.CorrectChannelSignal ().ToString ());
				theText.text = tempString;
				break;
			case SpeechTone.GaveUp:
				theText.text = stopWatching;
				break;
			default:
				theText.text = "???";
				break;
		}

		StartCoroutine (SayIt ((int)tone));
	}

	IEnumerator SayIt (int sfxIndex) {
		speechBubble.SetActive (true);
		if (voices.Length > 0 && mouth != null) {
			mouth.PlayOneShot (voices[sfxIndex]);
		}
		yield return new WaitForSeconds (speechDuration);
		speechBubble.SetActive (false);
	}
}

public enum SpeechTone {
	Bored,
	Annoyed,
	GaveUp
}
