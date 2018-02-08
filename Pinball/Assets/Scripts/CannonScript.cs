using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            // Reproducimos el sonido de la explosion
            GetComponent<AudioSource>().Play();
            // Instanciamos las particulas de explosion
            Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
