using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundEndBottomScript : MonoBehaviour
{

    public GameObject ball;
    public GameObject spawnPoint;

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
            //GetComponent<AudioSource>().Play();

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
