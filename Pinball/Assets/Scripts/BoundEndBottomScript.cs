///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: BoundEndBottomScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundEndBottomScript : MonoBehaviour
{

    #region Declaración de variables

    [Header("Ball Spawn")]
    [Tooltip("El GameObject que sera la bola que va a andar por el tablero")]
    public GameObject ball;
    [Tooltip("Es un GameObject cuyo contenido es una posición")]
    public GameObject spawnPoint;

    #endregion

    #region Métodos

    /// <summary>
    /// Método llamado cuando el GameObject es instanciado
    /// </summary>
    void Start()
    {
        /// Empieza generando la primera bola para que la partida pueda dar comienzo
        Instantiate(ball, spawnPoint.transform.position, Quaternion.identity).SetActive(true);
    }

    /// <summary>
    /// Método llamado cuando algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona es algo que tiene la tag Ball:
        if (collision.gameObject.tag.Equals("Ball"))
        {
            /// Destruimos la bola
            Destroy(collision.gameObject);
            /// Restamos una vida
            GameManager.lives--;

            /// Si aun nos quedan vidas:
            if (GameManager.lives != 0)
            {
                /// Reproducimos el sonido del evento de crear una nueva bola
                spawnPoint.gameObject.GetComponent<AudioSource>().Play();
                /// Creamos la nueva bola en el punto de Spawn
                Instantiate(ball, spawnPoint.GetComponent<Transform>().position, Quaternion.identity).SetActive(true);
            }
            /// Y si no quedan vidas:
            else
            {
                /// Cargamos la escena del Game Over
                SceneManager.LoadScene("GameOverMenu");
            }
        }
    }

    #endregion

}
