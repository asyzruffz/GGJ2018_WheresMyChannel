using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public GameObject pauseCanvas;
	
	void Start () {
		
	}
	
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
				SceneManager.LoadScene ("Test");
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
				Time.timeScale = 1;
				SceneManager.LoadScene ("Menu");
			}
			if (isResume) 
			{
				if (pauseObject != null)
					pauseObject.SetActive (false);
				if (pauseCanvas != null)
					pauseCanvas.SetActive (false);
				if (GameController.Instance) {
					GameController.Instance.SetPaused (false);
				}
			}
		}
	}
}
