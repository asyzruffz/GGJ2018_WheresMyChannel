using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	public bool isCredit;
	public bool isPlay;
	public bool isQuit;
	public bool isBack;
	private bool exiting;
	private bool entering;

	public AudioSource buttonSFX;

	public AudioClip buttonUpSFX;
	public AudioClip buttonDownSFX;

	public GameObject buttonTop;

	public GameObject menuObject;
	public GameObject creditObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		exiting = false;
		entering = true;
		if (entering) {
			buttonSFX.PlayOneShot(buttonDownSFX);
			buttonTop.transform.position = new Vector3 (buttonTop.transform.position.x, buttonTop.transform.position.y - 0.35f, 0);
		}
	}

	void OnMouseExit ()
	{
		if (entering) {
			buttonSFX.PlayOneShot(buttonUpSFX);
			buttonTop.transform.position = new Vector3 (buttonTop.transform.position.x, buttonTop.transform.position.y + 0.35f, 0);
			entering = false;
			exiting = true;
		}
	}

	void OnMouseUpAsButton()
	{
		if (!exiting) {
			buttonSFX.PlayOneShot (buttonUpSFX);
			buttonTop.transform.position = new Vector3 (buttonTop.transform.position.x, buttonTop.transform.position.y + 0.35f, 0);
			entering = false;
			if (isPlay) {
				Application.LoadLevel ("Test");
			}
			if (isCredit) {
				menuObject.SetActive (false);
				creditObject.SetActive (true);
			}
			if (isBack) {
				menuObject.SetActive (true);
				creditObject.SetActive (false);
			}
			if (isQuit) {
				Application.Quit ();
			}
		}
	}
}
