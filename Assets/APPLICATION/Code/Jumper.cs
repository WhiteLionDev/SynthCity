using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

	public float force = 10;

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name.Contains ("Player")) {
			other.gameObject.SendMessage ("Bounce", force, SendMessageOptions.RequireReceiver);
		}
	}
}
