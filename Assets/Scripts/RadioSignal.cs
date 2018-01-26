using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSignal : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnDrawGizmos () {
		CircleCollider2D col = GetComponent<CircleCollider2D> ();
		if (col) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere (transform.position, col.radius);
		}
	}
}
