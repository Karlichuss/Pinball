///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: StickController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour {

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona tiene la tag Ball:
        if (collision.gameObject.tag.Equals("Ball"))
        {
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();
        }
    }

    #endregion
}
