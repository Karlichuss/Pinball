using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

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
            // Reproducimos el sonido de la colision
            GetComponent<AudioSource>().Play();

            if (GameManager.ballSoundPlay)
            {
                // Controlamos que no vuelva a darse la orden de que suene la bola
                GameManager.ballSoundPlay = false;
                // Reproducimos en bucle el sonido de la bola rodando hasta que esta deje de entrar en contacto con el suelo
                collision.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            // Detenemos el sonido de la bola rodando, porque esta en el aire
            collision.gameObject.GetComponent<AudioSource>().Stop();
            // Volvemos a poner disponible el sonido
            GameManager.ballSoundPlay = true;
        }
    }
}
