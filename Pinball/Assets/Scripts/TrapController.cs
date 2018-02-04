using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Comprobamos que se ha alcanzado el ultimo nivel para aumentar la dificultad
        if (GameManager.level == 5)
        {
            // Si es el ultimo nivel, abrimos la trampilla
            GetComponent<Animation>().Play();
        }
    }
}
