using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {
	NONE,
	J1,
	J2
}

public class NPC : MonoBehaviour {

	public Team currentTeam = Team.NONE;

	public SpriteRenderer _renderer;
	public Color colorJ1;
	public Color colorJ2;
	public Color colorNeutral;

    public GameObject particlePlayer1;
    public GameObject particlePlayer2;
    public GameObject  particleNeutral;

    private AudioSource _audio;

	void Start() {
		_audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PaperJ1") {
			if (currentTeam == Team.NONE) {
				ChangeTeam (Team.J1);
			} else if (currentTeam == Team.J2) {
				ChangeTeam (Team.NONE);
			}
		} else if (other.tag == "PaperJ2") {
			if (currentTeam == Team.NONE) {
				ChangeTeam (Team.J2);
			} else if (currentTeam == Team.J1) {
				ChangeTeam (Team.NONE);
			}
		}
	}

	void ChangeTeam(Team targetTeam) {
		if (currentTeam != targetTeam) { 
			_audio.Play ();
			Team aux = currentTeam;
			currentTeam = targetTeam;
			switch (currentTeam) {
			case Team.J1:
				_renderer.color = colorJ1;
				Instantiate (particlePlayer1, transform.position, Quaternion.identity);
				GameManager.Instance.player1Score += 1;
                    break;
			case Team.J2:
				_renderer.color = colorJ2;
                Instantiate(particlePlayer2 , transform.position , Quaternion.identity);
				GameManager.Instance.player2Score += 1;
                    break;
			case Team.NONE:
				_renderer.color = colorNeutral;
				Instantiate (particleNeutral, transform.position, Quaternion.identity);
				if (aux == Team.J1) {
					GameManager.Instance.player1Score -= 1;
				} else if (aux == Team.J2) {
					GameManager.Instance.player2Score -= 1;
				}
                    break;
			}
		}
	}
}