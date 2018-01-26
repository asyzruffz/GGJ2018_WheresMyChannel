using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class RadioSignal : MonoBehaviour {

	CircleCollider2D col;

	void Start () {
		col = GetComponent<CircleCollider2D> ();
	}
	
	void Update () {
		
	}

	public float SignalRadius () {
		return col.radius;
	}

	void OnDrawGizmos () {
		if (col) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere (transform.position, col.radius);
		}
	}
}
