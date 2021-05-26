using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour {

	public int playerId;
	public float speed;
	public float jumpForce;
	public LayerMask whatIsGround;
	public LayerMask whatIsWall;
	public Spawner _spawner;
	public int maxPapers = 5;
	public int currentPapers = 5;

	public Text ammo;

	public AudioClip sJump;
	public AudioClip sShoot;

	public Transform groundCheck;
	public Transform wallCheck;
	private bool isFacingRight;

	private bool isGrounded;
	private bool isWalled;

	private Rigidbody2D _rigidbody;
	private Collider2D _collider;
	private Animator _anim;
	private AudioSource _audio;

	private Transform oneWayPlatform;
	private Transform prevOneWayPlatform;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_collider = GetComponent<Collider2D> ();
		_anim = GetComponentInChildren<Animator> ();
		_audio = GetComponent<AudioSource> ();
		isFacingRight = transform.localScale.x > 0;
		initialPosition = transform.position + Vector3.up;
	}

	void FixedUpdate() {
		if (GameManager.Instance.playing) {
			float moveHorizontal = Input.GetAxis ("Horizontal" + playerId.ToString ());

			Vector3 startPoint = groundCheck.position - new Vector3 (_collider.bounds.size.x / 2, 0, 0);
			Vector3 endPoint = groundCheck.position + new Vector3 (_collider.bounds.size.x / 2, 0, 0);

			Debug.DrawLine (startPoint, endPoint, Color.green);
			isGrounded = Physics2D.Linecast (startPoint, endPoint, whatIsGround);

			startPoint = wallCheck.position - new Vector3 (0, _collider.bounds.size.y / 2, 0);
			endPoint = wallCheck.position + new Vector3 (0, _collider.bounds.size.y / 2, 0);

			Debug.DrawLine (startPoint, endPoint, Color.blue);
			isWalled = Physics2D.Linecast (startPoint, endPoint, whatIsWall);

			Vector3 move = new Vector3 (moveHorizontal * speed * Time.deltaTime, _rigidbody.velocity.y, 0f);

			if (moveHorizontal < 0 && isFacingRight) {
				Flip ();
			} else if (moveHorizontal > 0 && !isFacingRight) {
				Flip ();
			}

			if (!isWalled)
				_rigidbody.velocity = move;
			else
				_rigidbody.velocity = new Vector3 (0, _rigidbody.velocity.y, 0f);

			_anim.SetBool ("grounded", isGrounded);
			_anim.SetFloat ("hSpeed", Mathf.Abs (_rigidbody.velocity.x));
			_anim.SetFloat ("vSpeed", _rigidbody.velocity.y);
		}

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.playing) {
			if (Input.GetButtonDown ("Jump" + playerId.ToString ())) {
				Jump ();
			}

			if (Input.GetButtonDown ("Shoot" + playerId.ToString ())) {
				Shoot ();
			}

			ammo.text = currentPapers.ToString ();
		}
	}

	void Flip() {
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump() {
		if (isGrounded) {
			if (Input.GetAxis ("Vertical" + playerId.ToString()) < 0 && oneWayPlatform != null) {
				prevOneWayPlatform = oneWayPlatform;
				Physics2D.IgnoreCollision (_collider, oneWayPlatform.GetComponent<Collider2D> ());
				StartCoroutine (ReverseIgnoreCollision ());
			} else {
				_audio.PlayOneShot (sJump);
				_rigidbody.velocity = Vector3.zero;
				_rigidbody.AddForce (new Vector2 (0, jumpForce));
				_anim.SetFloat ("vSpeed", _rigidbody.velocity.y);
			}
		}
	}

	void Bounce(float force) {
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce (new Vector2 (0, force));
		_anim.SetFloat ("vSpeed", _rigidbody.velocity.y);
	}

	void Shoot() {
		_rigidbody.velocity = new Vector3 (0, _rigidbody.velocity.y, 0f);
		if (currentPapers > 0) {
			_audio.PlayOneShot (sShoot);
			_anim.SetTrigger ("shoot");
			_spawner.SpawnObject ();
			currentPapers -= 1;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Si colisiona con una OneWayPlatform
		if (col.gameObject.layer == 11) {
			oneWayPlatform = col.gameObject.transform;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		// Si colisiona con una OneWayPlatform
		if (col.gameObject.layer == 11) {
			oneWayPlatform = null;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.tag == "ReloaderJ" + playerId.ToString ()) {
			currentPapers = maxPapers;
		} else if (other.gameObject.name.Contains ("Death")) {
			currentPapers = 0;
			transform.position = initialPosition;
		}
	}

	private IEnumerator ReverseIgnoreCollision() {
		yield return new WaitForSeconds(0.9f);
		Physics2D.IgnoreCollision (_collider, prevOneWayPlatform.GetComponent<Collider2D> (), false);
		prevOneWayPlatform = null;
	}

	void IncrementSpeed(float plus) {
		speed *= plus;
	}

}
