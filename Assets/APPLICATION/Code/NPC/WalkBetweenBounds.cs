using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WalkBetweenBoundsSM {
	WAITING,
	WALKING
}

public class WalkBetweenBounds : MonoBehaviour {

	public float walkSpeed = 5;
	public float waitingTime = 2.5f;

	public int dir = 1;
	public float offset = 0;

	public WalkBetweenBoundsSM currentState = WalkBetweenBoundsSM.WAITING;

	private bool isFacingRight;

	private Rigidbody2D _rigidbody;

	private float t = 0;

	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		isFacingRight = transform.localScale.x > 0;
		t = waitingTime - offset;
	}

	// Update is called once per frame
	void Update () {
		ManageBehabiour ();
	}

	void ManageBehabiour () {
		switch (currentState) {
		case WalkBetweenBoundsSM.WAITING:
			t += Time.deltaTime;
			if (t >= waitingTime) {
				currentState = WalkBetweenBoundsSM.WALKING;
				t -= waitingTime;
			}
			break;
		case WalkBetweenBoundsSM.WALKING:
			_rigidbody.velocity = new Vector3 (dir * walkSpeed * Time.deltaTime, _rigidbody.velocity.y, 0f);

			if (dir < 0 && isFacingRight) {
				Flip ();
			} else if (dir > 0 && !isFacingRight) {
				Flip ();
			}
			break;
		}
	}

	void Flip() {
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 13) {
			dir *= -1;
			_rigidbody.velocity = new Vector3 (0, _rigidbody.velocity.y, 0f);
			currentState = WalkBetweenBoundsSM.WAITING;
		}
	}
}
