using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Spawnable {

	public float speed;
	public float lifeTime;
	public LayerMask destroyerLayers;

	private Vector3 dir = Vector3.zero;

	private float t = 0;

	void Update()
	{
		if (Active) {

			if (dir == Vector3.zero) {
				if (Spawner.transform.parent.localScale.x > 0)
					dir = Vector3.right;
				else
					dir = Vector3.left;
			}

			transform.Translate (dir * speed * Time.deltaTime);

			t += Time.deltaTime;
			if (t >= lifeTime) {
				Spawner.RemoveObject(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject.layer & destroyerLayers.value) == 0)
		{
			Spawner.RemoveObject(gameObject);
		}
	}

	public override void SetActiveState()
	{		
		//gameObject.SetActive (true);
		Active = true;
	}

	public override void SetInactiveState()
	{
		Active = false;
		dir = Vector3.zero;
		t = 0;
		gameObject.SetActive (false);
	}
}
