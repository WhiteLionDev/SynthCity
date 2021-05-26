using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour {

    ParticleSystem partSyst;
	void Start () {
        partSyst = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(partSyst != null) {
            if (partSyst.isStopped) {
                Destroy(partSyst.gameObject);
            }
        }

	}
}
