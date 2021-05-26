using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public ObjectPool objectPool;
	[Range(1f, 5f)]
	public float coolDownTime;

	public void SpawnObject()
	{
		if (objectPool != null)
		{
			GameObject go = objectPool.GetGameObject();
			go.transform.position = this.transform.position;
			go.GetComponent<Spawnable>().Spawner = this;
			Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
		}
	}

	public void RemoveObject(GameObject go)
	{
		if (objectPool != null)
		{
			go.transform.position = objectPool.transform.position;
			objectPool.ReleaseGameObject(go);
		}
	}
		
}
