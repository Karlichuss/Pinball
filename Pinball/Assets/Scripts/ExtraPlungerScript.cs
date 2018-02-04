using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlungerScript : MonoBehaviour
{

    public float power;

    GameObject ball;
    public GameObject trap;

    // Use this for initialization
    void Start()
    {
        
    }

    IEnumerator LaunchBall()
    {
        // Reproducimos el sonido del evento
        GetComponent<AudioSource>().Play();

        // Hacemos tiempo a que se reproduzca el sonido
        Time.timeScale = 1;

        // Pausamos el hilo por 1 segundo
        yield return new WaitForSeconds(1.0f);

        // Lanzamos la bola hacia arriba
        ball.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);

        // Pausamos 0.5 segundos para dar tiempo a que la bola salga del plunger
        yield return new WaitForSeconds(0.5f);

        // Cerramos la trampilla para que este extra no pueda volver a usarse
        trap.gameObject.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            ball = other.gameObject;
            StartCoroutine(LaunchBall());
        }
    }
}
