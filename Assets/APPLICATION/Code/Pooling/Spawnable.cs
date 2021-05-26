using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour {

	public Spawner Spawner { get; set; }
	public bool Active { get; set; }

	public abstract void SetActiveState();

	public abstract void SetInactiveState();
}
