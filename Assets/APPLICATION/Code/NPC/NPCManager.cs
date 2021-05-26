using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

	[HideInInspector]
	public NPC[] npcList;

	private static NPCManager _instance;

	public static NPCManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<NPCManager>();
				if (_instance == null)
				{
					GameObject obj = new GameObject();
					obj.name = typeof(NPCManager).ToString();
					_instance = obj.AddComponent<NPCManager>();
				}
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Awake () {
		npcList = FindObjectsOfType<NPC> ();
	}

}
