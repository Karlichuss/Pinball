///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: CannonScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

    #region Declaración de variables

    // Particulas de explosión
    public GameObject explosion;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cada vez que algo sale de la CollisionBox del GameObject
    /// </summary>
    /// <param name="other">Lo que sale de la CollisionBox</param>
    private void OnTriggerExit(Collider other)
    {
        /// Si lo que sale tiene la tag Ball:
        if (other.gameObject.tag.Equals("Ball"))
        {
            ///     Reproducimos el sonido de la explosión
            GetComponent<AudioSource>().Play();
            ///     Instanciamos las particulas de explosión
            Instantiate(explosion, GetComponent<Transform>().position, Quaternion.identity);
        }
    }

    #endregion

}
