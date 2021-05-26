using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrail : MonoBehaviour {

    public TrailRenderer[] trails;



    protected virtual void OnEnable()
    {


        for (int i = 0; i < trails.Length; i++)        // Si tiene trails asignados, los resetea (es importante que la particula se prenda siempre despues de posicionarse)
        {
            trails[i].Clear();
            trails[i].enabled = true;
        }
     
    }

    protected void OnDisable()
    {
        
        for(int i = 0; i < trails.Length; i++) {
            trails[i].Clear();
            trails[i].enabled = false;

        }
    }
}
