using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RageMeter : MonoBehaviour {

	public Uncle person;

	Slider meter;

	void Start () {
		meter = GetComponent<Slider> ();
	}
	
	void Update () {
		meter.value = person.rage;
	}
}
