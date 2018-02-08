using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Comprobamos que se ha alcanzado cierto nivel para aumentar la dificultad
        if (GameManager.level == 4 && !GameManager.trap2Activated)
        {
            GameManager.trap2Activated = true;

            // Abrimos la trampilla
            GetComponent<Animation>().Play();
        }
    }
}
