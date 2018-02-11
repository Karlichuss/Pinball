///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: BumperController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

    #region Declaración de variables

    // Partículas de vapor
    public GameObject steam;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona tiene la tag Ball
        if (collision.gameObject.tag.Equals("Ball"))
        {
            /// Puntuamos
            GameManager.score += 10 * GameManager.level;
            /// Activamos la animacion del bumper
            GetComponent<Animation>().Play();
            /// Reproducimos sonido
            GetComponent<AudioSource>().Play();
            /// Instanciamos el humo
            Instantiate(steam, GetComponent<Transform>().position, Quaternion.identity);
        }
    }

    #endregion

}
