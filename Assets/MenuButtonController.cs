using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	public bool isCredit;
	public bool isPlay;
	public bool isQuit;
	public bool isBack;
	public bool isMenu;
	public bool isResume;

	private bool exiting;
	private bool entering;

	public AudioSource buttonSFX;

	public AudioClip buttonUpSFX;
	public AudioClip buttonDownSFX;

	public GameObject buttonTop;

	public GameObject menuObject;
	public GameObject creditObject;
	public GameObject pauseObject;

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
				if(menuObject != null) menuObject.SetActive (false);
				if(creditObject != null) creditObject.SetActive (true);
			}
			if (isBack) {
				if(menuObject != null) menuObject.SetActive (true);
				if(creditObject != null) creditObject.SetActive (false);
			}
			if (isQuit) {
				Application.Quit ();
			}
			if (isMenu) {
				Application.LoadLevel ("Menu");
			}
			if (isResume) 
			{
				if (pauseObject != null)
					pauseObject.SetActive (false);
			}
		}
	}
}
