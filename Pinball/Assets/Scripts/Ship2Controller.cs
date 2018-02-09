using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2Controller : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball") && GameManager.level == 5)
        {
            // Puntuamos
            GameManager.score += 150;
            // Reproducimos el sonido de la colision
            GetComponent<AudioSource>().Play();
            // Instanciamos la explosion
            Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
            // Activamos la animacion del barco
            GetComponent<Animation>().Play("Ship2DiveAnimation");
        }
        else if (collision.gameObject.tag.Equals("Ball"))
        {
            // Puntuamos
            GameManager.score += 25 * GameManager.level;
            // Reproducimos el sonido de la colision
            GetComponent<AudioSource>().Play();
            // Activamos la animacion del barco
            GetComponent<Animation>().Play("Ship2FloatingAnimation");
        }
    }
}
