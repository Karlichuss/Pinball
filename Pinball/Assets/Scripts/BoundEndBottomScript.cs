using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            // Si aun nos quedan vidas, volvemos a colocar una nueva bola. Si no, Game Over.
            if (GameManager.lives != 0)
            {
                spawnPoint.gameObject.GetComponent<AudioSource>().Play();
                Instantiate(ball, spawnPoint.GetComponent<Transform>().position, Quaternion.identity).SetActive(true);
            }
            else
            {
                // Cargamos la escena del Game Over
                SceneManager.LoadScene("GameOverMenu");
            }
        }
    }
}
