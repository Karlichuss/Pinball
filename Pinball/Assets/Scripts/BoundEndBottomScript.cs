using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundEndBottomScript : MonoBehaviour
{

    public GameObject ball;
    public GameObject spawnPoint;

    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;
    public GameObject powerUp4;

    // Use this for initialization
    void Start()
    {
        Instantiate(ball, spawnPoint.transform.position, Quaternion.identity).SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            // Destruimos la bola
            Destroy(collision.gameObject);
            // Restamos una vida
            GameManager.lives--;
            // Reseteamos de nivel
            GameManager.level = 1;
            // Reproducimos el sonido de lostlife
            GetComponent<AudioSource>().Play();
            // Volvemos a poner en el tablero todos los powerUps
            powerUp1.SetActive(true);
            powerUp2.SetActive(true);
            powerUp3.SetActive(true);
            powerUp4.SetActive(true);

            // Si aun nos quedan vidas, volvemos a colocar una nueva bola. Si no, Game Over.
            if (GameManager.lives != 0)
            {
                Instantiate(ball, spawnPoint.transform.position, Quaternion.identity).SetActive(true);
            }
            else
            {

            }
        }
    }
}
