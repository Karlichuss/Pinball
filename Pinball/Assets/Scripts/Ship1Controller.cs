///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: Ship1Controller.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1Controller : MonoBehaviour {

    #region Declaración de variables

    // Particulas de la explosión
    public GameObject explosion;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cada vez que algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona tiene la tag Ball y el nivel del juego ya es 5:
        if (collision.gameObject.tag.Equals("Ball") && GameManager.level == 5)
        {
            ///     Puntuamos
            GameManager.score += 150;
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();
            ///     Instanciamos la explosión
            Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
            ///     Activamos la animación del barco hundiendose
            GetComponent<Animation>().Play("Ship1DiveAnimation");
        }
        /// Si tiene la tag Ball:
        else if (collision.gameObject.tag.Equals("Ball"))
        {
            ///     Puntuamos
            GameManager.score += 25 * GameManager.level;
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();
            ///     Activamos la animación del barco
            GetComponent<Animation>().Play("Ship1FloatingAnimation");
        }
    }

    #endregion
}
