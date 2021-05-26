using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierType {
	EXTRA_SPEED,
	TRANSPORT,
	SAVOTAGE
}

public class Modifier : MonoBehaviour {

	public ModifierType mType;

	public float speed = 10;

	// Use this for initialization
	void Start () {
		switch (Random.Range(0,3)) {
		case 0:
			mType = ModifierType.EXTRA_SPEED;
			break;
		case 1:
			mType = ModifierType.TRANSPORT;
			break;
		case 2:
			mType = ModifierType.SAVOTAGE;
			break;
		default:
			mType = ModifierType.EXTRA_SPEED;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name.Contains ("Player")) {
			switch (mType) {
			case ModifierType.EXTRA_SPEED:
				other.gameObject.SendMessage ("IncrementSpeed", 1.5f, SendMessageOptions.RequireReceiver);
				break;
			case ModifierType.TRANSPORT:
				Vector3 aux = GameManager.Instance.player1.transform.position;
				GameManager.Instance.player1.transform.position = GameManager.Instance.player2.transform.position;
				GameManager.Instance.player2.transform.position = aux;
				break;
			case ModifierType.SAVOTAGE:
				Player2D j = other.gameObject.GetComponent<Player2D> ();
				if (j.playerId == 1) {
					GameManager.Instance.player2.currentPapers = 0;
				} else {
					GameManager.Instance.player1.currentPapers = 0;
				}
				break;
			}

			Destroy (gameObject);
		}
	}

}
