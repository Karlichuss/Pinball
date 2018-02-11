///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: InterfacePinball.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfacePinball : MonoBehaviour {

    #region Declaración de variables

    // Campos de texto dentro del Canvas
    public Text lives;
    public Text level;
    public Text score;

    #endregion

    #region Métodos
	
	/// <summary>
    /// Método que es llamado con cada frame
    /// </summary>
	void Update () {
        /// Vamos actualizando el numero de vidas que quedan
        lives.text = string.Format("Lives: {0}", GameManager.lives);
        /// El nivel actual
        level.text = string.Format("Level: {0}", GameManager.level);
        /// Y la puntuacion
        score.text = string.Format("Score: {0}", GameManager.score);
    }

    #endregion
}
