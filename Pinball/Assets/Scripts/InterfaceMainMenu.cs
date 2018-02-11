///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: InterfaceMainMenu.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceMainMenu : MonoBehaviour
{

    #region Métodos
    
    /// <summary>
    /// Método que es llamado cuando se pulse el botón correspondiente
    /// </summary>
    public void Click()
    {
        /// Ponemos los valores por defecto
        GameManager.lives = 3;
        GameManager.level = 1;
        GameManager.score = 0;
        GameManager.trap1Activated = false;
        GameManager.trap2Activated = false;
        
        /// Reproducimos el sonido de la tecla pulsada
        GetComponent<AudioSource>().Play();

        /// Cargamos la escena del juego
        SceneManager.LoadScene("PinballCustom");
    }

    #endregion
}