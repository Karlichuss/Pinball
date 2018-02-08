using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

    public GameObject steam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            // Puntuamos
            GameManager.score += 10 * GameManager.level;
            // Activamos la animacion del bumper
            GetComponent<Animation>().Play();
            // Reproducimos sonido
            GetComponent<AudioSource>().Play();
            // Instanciamos el humo
            Instantiate(steam, GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
