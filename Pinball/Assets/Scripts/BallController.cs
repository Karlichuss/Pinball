using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (GetComponent<Transform>().position.y >= 1)
        {
            // Calculamos el volumen del sonido del rozamiento de la bola con el suelo segun su velocidad de movimiento
            GetComponent<AudioSource>().volume = Mathf.Clamp((GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.z), 0.0f, 1.0f);
        }
        else
        {
            // Silenciamos el sonido de la bola rodando en el suelo, ya que esta en el aire
            GetComponent<AudioSource>().volume = 0.0f;
        }
    }
}
