using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // GameObjects para instanciar particulas
    public GameObject explosion;
    public GameObject steam;
    public GameObject fireworks;

    public float volumen;

    // Use this for initialization
    void Start()
    {
        // Reproducimos en bucle el sonido de la bola rodando hasta que esta deje de entrar en contacto con el suelo
        GetComponent<AudioSource>().Play();
    }

    private void LateUpdate()
    {
        if (GetComponent<Transform>().position.y >= 1)
        {
            // Calculamos el volumen del sonido del rozamiento de la bola con el suelo segun su velocidad de movimiento
            GetComponent<AudioSource>().volume = Mathf.Clamp((GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.z) * volumen, 0, 1);
        }
        else
        {
            // Silenciamos el sonido de la bola rodando en el suelo, ya que esta en el aire
            GetComponent<AudioSource>().volume = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Cannon"))
        {
            // Reproducimos el sonido de la explosion
            collision.GetComponent<AudioSource>().Play();
            // Instanciamos las particulas de explosion
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag.Equals("PowerUp"))
        {
            // Puntuamos
            GameManager.score += 50;
            // Subimos de nivel
            GameManager.level += 1;
            // Reproducimos el sonido del powerup
            collision.GetComponent<AudioSource>().Play();
            // Instanciamos las particulas de powerup
            Instantiate(fireworks, transform.position, Quaternion.identity);
            // El powerup desaparece
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bumper"))
        {
            // Puntuamos
            GameManager.score += 10;
            // Activamos la animacion del bumper
            collision.gameObject.GetComponent<Animation>().Play();
            // Reproducimos sonido
            collision.gameObject.GetComponent<AudioSource>().Play();
            // Instanciamos el humo
            Instantiate(steam, collision.gameObject.transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag.Equals("Ship"))
        {
            // Puntuamos
            GameManager.score += 25;
            // Reproducimos el sonido de la colision
            collision.gameObject.GetComponent<AudioSource>().Play();
            // Instanciamos la explosion
            //Instantiate(explosion, transform.position, Quaternion.identity);
            // Activamos la animacion del barco
            collision.gameObject.GetComponent<Animation>().Play();
            // Destruimos el barco
            //collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Ship"))
        {
            // Puntuamos
            GameManager.score += 150;
            // Reproducimos el sonido de la explosion
            // collision.gameObject.GetComponent<AudioSource>().Play();
            // Instanciamos la explosion
            Instantiate(explosion, transform.position, Quaternion.identity);
            // Destruimos el barco
            //collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Wall"))
        {
            // Reproducimos el sonido de la colision
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag.Equals("Floor"))
        {
            // Reproducimos el sonido de la colision
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            
        }
    }

}
