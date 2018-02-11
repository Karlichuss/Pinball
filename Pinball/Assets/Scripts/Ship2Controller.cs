///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: Ship2Controller.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2Controller : MonoBehaviour {

    #region Declaración de variables

    // Particulas de la explosión
    public GameObject explosion;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona tiene la tag Ball y el nivel es 5:
        if (collision.gameObject.tag.Equals("Ball") && GameManager.level == 5)
        {
            ///     Puntuamos
            GameManager.score += 150;
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();
            ///     Instanciamos la explosión
            Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
            ///     Activamos la animación del barco
            GetComponent<Animation>().Play("Ship2DiveAnimation");
        }
        /// Si lo que colisona tiene la tag de Ball:
        else if (collision.gameObject.tag.Equals("Ball"))
        {
            ///     Puntuamos
            GameManager.score += 25 * GameManager.level;
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();
            ///     Activamos la animación del barco
            GetComponent<Animation>().Play("Ship2FloatingAnimation");
        }
    }

    #endregion

}
