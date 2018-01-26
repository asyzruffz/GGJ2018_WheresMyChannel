using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaController : MonoBehaviour {

	public float sensitivity = 1;
	
	void Update () {
		if (Input.GetMouseButton (0)) {
			float h = Input.GetAxis ("Mouse X") * sensitivity;
			float v = Input.GetAxis ("Mouse Y") * sensitivity;
			//Debug.Log ("h: " + h + ", v: " + v);

			transform.Translate (h, v, 0, Space.World);
		}
	}
}
