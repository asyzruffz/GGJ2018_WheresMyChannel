using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InnerFire : MonoBehaviour {

	public Uncle person;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		int fireState = (person.patience >= person.coolOffTime) ? 0 : (person.patience > 0) ? 1 : 2;
		anim.SetInteger ("AnimState", fireState);

		float scale = 1 + (1 - Mathf.InverseLerp (0.0f, person.coolOffTime, person.patience)) * 0.5f;
		transform.localScale = new Vector3 (scale, scale, 1);
	}
}
